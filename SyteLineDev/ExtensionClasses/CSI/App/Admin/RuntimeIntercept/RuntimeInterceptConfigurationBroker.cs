using CSI.Data;
using CSI.Data.CRUD;
using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSI.Admin.RuntimeIntercept
{
    /// <summary>
    /// the broker will using reflection to get the record from assembly CSI.RTI which could be found on IDO Custom Assembly
    /// </summary>
    public class RuntimeInterceptConfigurationBroker : IRuntimeInterceptConfigurationBroker
    {
        readonly string assemblyFullName = "CSI.RTI, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
        readonly string nameSpace = "CSI.RTI";
        readonly string methodName = "LoadAll";
        readonly string className = "RTIRecords";
        readonly IAssemblyLoader assemblyLoader;
        readonly MG.ILogger logger;
        readonly IAssemblyScanner assemblyScanner;
        readonly IAssemblyInvoker assemblyInvoker;
        readonly IMsgApp msgApp;
        public RuntimeInterceptConfigurationBroker(IAssemblyLoader assemblyLoader, MG.ILogger logger, IAssemblyScanner assemblyScanner, IAssemblyInvoker assemblyInvoker, IMsgApp msgApp)
        {
            this.assemblyLoader = assemblyLoader;
            this.logger = logger;
            this.assemblyScanner = assemblyScanner;
            this.assemblyInvoker = assemblyInvoker;
            this.msgApp = msgApp;
        }

        public string GenerateMetadata(ICollectionLoadResponse rti)
        {
            StringBuilder MetadataCode = new StringBuilder();
            MetadataCode.AppendLine("using CSI.Data; ");
            MetadataCode.AppendLine("using System.Collections.Generic;  ");
            MetadataCode.AppendLine($"namespace {nameSpace} ");
            MetadataCode.AppendLine("{ ");  //Namespace start
            MetadataCode.AppendLine($"    public class {className} ");
            MetadataCode.AppendLine("    { ");  //class definition start.
            MetadataCode.AppendLine("         readonly IList<IRuntimeInterceptRecord> records; ");
            MetadataCode.AppendLine($"        public {className}()  ");  //Constructor
            MetadataCode.AppendLine("         {  ");
            MetadataCode.AppendLine("            records = new List<IRuntimeInterceptRecord>(); ");
            MetadataCode.AppendLine("            InitRTI();  ");
            MetadataCode.AppendLine("         } ");
            MetadataCode.AppendLine("        private void InitRTI() ");
            MetadataCode.AppendLine("        { ");
            if (rti?.Items != null)
            {
                foreach (var item in rti?.Items)
                {
                    MetadataCode.AppendLine($"       records.Add(new RuntimeInterceptRecord(true,\"{item.GetValue<string>("AssemblyName")}\", \"{item.GetValue<string>("AssemblyFullName")}\", ERuntimeIntercept.{item.GetValue<string>("RuntimeIntercept")} ");
                    var customAssembly = this.assemblyLoader.GetAssembly(item.GetValue<string>("AssemblyFullName"));
                    var applicationAssembly = this.assemblyLoader.GetAssembly(Assembly.GetExecutingAssembly().FullName);
                    MetadataCode.Append(", new Dictionary<string, string>() { ");
                    IDictionary<Type, IList<Type>> customTypes = this.assemblyScanner.LoadRuntimeInterceptClasses(applicationAssembly, customAssembly, item.GetValue<ERuntimeIntercept>("RuntimeIntercept"));
                    if (customTypes != null)
                    {
                        string spliteSymbol = string.Empty;
                        foreach (var types in customTypes)
                        {
                            if (types.Value == null || types.Value.Count == 0) continue;

                            if (types.Value.Count > 1)
                            {
                                (int returnCode, string exceptionMessage) = this.msgApp.MsgAppSp("", "E=MultipleCustomImplementationsNotAllowed", customAssembly.FullName, types.Key.Name);
                                throw new Exception(exceptionMessage);
                            }
                            MetadataCode.Append($"{spliteSymbol}{{\"{types.Key}\",\"{types.Value[0]}\"}}");
                            spliteSymbol = ",";
                        }
                    }
                    MetadataCode.Append("}));");
                }
            }
            MetadataCode.AppendLine("        } ");
            MetadataCode.AppendLine("        public IList<IRuntimeInterceptRecord> LoadAll() ");
            MetadataCode.AppendLine("        { return records; }");
            MetadataCode.AppendLine("    } ");  //class definition end.
            MetadataCode.AppendLine("} ");//Namespace end

            return MetadataCode.ToString();
        }

        //in this class, the ETP records are maintained by customer will be looked up.
        public IList<IRuntimeInterceptRecord> LoadAll()
        {
            //the reason why add the try catch block is to avoid no such ido exists.
            try
            {
                Assembly RuntimeInterceptConfiguration = assemblyLoader.GetAssembly(assemblyFullName);

                Type type = assemblyLoader.GetType(RuntimeInterceptConfiguration, $"{nameSpace}.{className}");
                var rti = assemblyInvoker.CreateInstance(type);
                return assemblyInvoker.Invoke<IList<IRuntimeInterceptRecord>>(rti, methodName, new object[] { });
            }
            catch (Exception err)
            {
                this.logger.Error("RuntimeInterceptConfigurationBroker", err.Message);
                return new List<IRuntimeInterceptRecord>();
            }
        }
    }
}
