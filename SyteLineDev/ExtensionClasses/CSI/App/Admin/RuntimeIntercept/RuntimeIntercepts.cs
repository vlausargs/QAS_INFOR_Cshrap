using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CSI.CRUD.Admin;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data;
using System.Reflection;
using CSI.MG.MGCore;

namespace CSI.Admin.RuntimeIntercept
{
    public interface IRuntimeIntercepts
    {
        ICollectionLoadResponse LoadRuntimeIntercepts(string filter);
        void GenerateAssemblyCodesBaseOnRuntimeInterceptConfigurationRecrods();
        ICollectionLoadResponse LoadRuntimeInterceptStatus(string applicationAssembly, string customAssemblyName, ERuntimeIntercept eRuntimeIntercept);
    }
    public class RuntimeIntercepts : IRuntimeIntercepts
    {
        readonly IRuntimeInterceptConfigurationBroker runtimeInterceptConfigurationBroker;
        readonly IRuntimeInterceptsCRUD RuntimeInterceptsCRUD;
        readonly IObjCustomAssemblyCRUD objCustomAssemblyCRUD;
        readonly IObjCustomAssemblySourceCRUD objCustomAssemblySourceCRUD;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IAssemblyScanner assemblyScanner;
        readonly IAssemblyLoader mGAssemblyLoader;
        readonly IMsgApp msgApp;
        public RuntimeIntercepts(CSI.CRUD.Admin.IRuntimeInterceptsCRUD RuntimeInterceptsCRUD,
            IObjCustomAssemblyCRUD objCustomAssemblyCRUD, IObjCustomAssemblySourceCRUD objCustomAssemblySourceCRUD,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            IAssemblyScanner assemblyScanner, IMsgApp msgApp, IRuntimeInterceptConfigurationBroker runtimeInterceptConfigurationBroker, IAssemblyLoader mGAssemblyLoader)
        {
            this.RuntimeInterceptsCRUD = RuntimeInterceptsCRUD;
            this.objCustomAssemblyCRUD = objCustomAssemblyCRUD;
            this.objCustomAssemblySourceCRUD = objCustomAssemblySourceCRUD;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.assemblyScanner = assemblyScanner;
            this.msgApp = msgApp;
            this.runtimeInterceptConfigurationBroker = runtimeInterceptConfigurationBroker;
            this.mGAssemblyLoader = mGAssemblyLoader;
        }
        /// <summary>
        /// this API is to list all elements in the Enum which could be selected in a combbox. 
        /// </summary>
        /// <param name="filter">User could filter data</param>
        /// <returns></returns>
        public ICollectionLoadResponse LoadRuntimeIntercepts(string filter)
        {
            DataTable classes = new DataTable("RuntimeIntercepts");
            DataColumn column = new DataColumn("RuntimeIntercept", System.Type.GetType("System.String"));
            classes.Columns.Add(column);
            foreach (string className in Enum.GetNames(typeof(Data.ERuntimeIntercept)))
            {
                if (className.Equals("None")) continue;
                DataRow row = null;
                if (string.IsNullOrEmpty(filter) || className.Contains(filter))
                {
                    row = classes.NewRow();
                    row["RuntimeIntercept"] = className;
                    classes.Rows.Add(row);
                }
            }
            return dataTableToCollectionLoadResponse.Process(classes);
        }
        public void GenerateAssemblyCodesBaseOnRuntimeInterceptConfigurationRecrods()
        {
            string assemblyName = "CSI.RTI";
            string assemblyFileName = "CSI.RTI";
            string codeLanauge = "C#";
            int assemblyTypeSource = 1;  //1 means source code. 0 means binary.
            string assemblyReferences = "CSI.Data, netstandard.dll";
            string accessAs = "BaseSyteLine";
            string sourceFileName = "RuntimeInterceptConfigurationRecords";

            int assemblyIsUnderConstruction = 1;
            if (this.objCustomAssemblyCRUD.Exists(assemblyName, assemblyIsUnderConstruction) == true)
            {
                (int returnCode,string exceptionMessage) = this.msgApp.MsgAppSp("", "E=AssemblyIsCheckedOut", assemblyName);
                throw new Exception(exceptionMessage); // ($"The assembly {assemblyName} is under construction. Please unlock it!");
            }
            var RTIRecords = this.RuntimeInterceptsCRUD.LoadAll();
            
            string souceCode = runtimeInterceptConfigurationBroker.GenerateMetadata(RTIRecords);
            assemblyIsUnderConstruction = 0;
            if (this.objCustomAssemblyCRUD.Exists(assemblyName, assemblyIsUnderConstruction) == true)
                this.objCustomAssemblyCRUD.Update(assemblyName, codeLanauge, assemblyReferences, assemblyTypeSource);
            else
                this.objCustomAssemblyCRUD.Insert(assemblyName, codeLanauge, assemblyReferences, assemblyFileName, accessAs, assemblyTypeSource);

            if (this.objCustomAssemblySourceCRUD.Exists(assemblyName, sourceFileName))
                this.objCustomAssemblySourceCRUD.Update(assemblyName, sourceFileName, souceCode);
            else
                this.objCustomAssemblySourceCRUD.Insert(assemblyName, sourceFileName, souceCode);
        }

        private DataTable InitResultForRuntimeInterceptStatus()
        {
            DataTable data = new DataTable("RuntimeInterceptExtendedClasses");
            data.Columns.Add("ApplicationClass");
            data.Columns.Add("ApplicationInterface");
            data.Columns.Add("CustomClass");
            data.Columns.Add("Comment");
            return data;
        }
        private DataTable AddRuntimeInterceptStatus(DataTable data, string applicationClass, string applicationInterface, string customClass, string comment)
        {
            if(data == null) data = InitResultForRuntimeInterceptStatus(); 
            DataRow row = data.NewRow();
            row[0] = applicationClass;
            row[1] = applicationInterface;
            row[2] = customClass;
            row[3] = comment;
            data.Rows.Add(row);
            return data;
        }
        public ICollectionLoadResponse LoadRuntimeInterceptStatus(string applicationAssemblyName, string customAssemblyName, ERuntimeIntercept eRuntimeIntercept)
        {
            var data = InitResultForRuntimeInterceptStatus();
            if(string.IsNullOrEmpty(applicationAssemblyName)||string.IsNullOrEmpty(customAssemblyName)) return dataTableToCollectionLoadResponse.Process(data);
            string applicationAssemblyFullName = objCustomAssemblyCRUD.GetFullName(applicationAssemblyName);
            if (string.IsNullOrEmpty(applicationAssemblyFullName)) return dataTableToCollectionLoadResponse.Process(data);
            var applicationAssembly = this.mGAssemblyLoader.GetAssembly(applicationAssemblyFullName);
            string customAssemblyFullName = objCustomAssemblyCRUD.GetFullName(customAssemblyName);
            if (string.IsNullOrEmpty(customAssemblyFullName)) return dataTableToCollectionLoadResponse.Process(data);
            var customAssembly = this.mGAssemblyLoader.GetAssembly(customAssemblyFullName);
            if (applicationAssembly == null || customAssembly == null) return dataTableToCollectionLoadResponse.Process(data);

            foreach (var appClass in this.assemblyScanner.LoadApplicationClasses(applicationAssembly, eRuntimeIntercept))
            {
                foreach (var applicationInterface in appClass.GetInterfaces())
                {
                    var customClasses = assemblyScanner.LoadRuntimeInterceptClasses(customAssembly, applicationInterface);
                    if (customClasses == null || customClasses.Count == 0)
                    { 
                        data = AddRuntimeInterceptStatus(data,appClass.Name, applicationInterface.Name, string.Empty, string.Empty);
                        continue;
                    }
                    string comment = string.Empty;
                    int returnCode = 0;
                    if (customClasses.Count > 1)
                        (returnCode, comment) = this.msgApp.MsgAppSp("", "E=MultipleCustomImplementationsNotAllowed", customAssembly.FullName, applicationInterface.Name);
                    foreach (var customClass in customClasses)
                        data = AddRuntimeInterceptStatus(data, appClass.Name, applicationInterface.Name, customClass.Name, comment);                   
                }
            }
            return dataTableToCollectionLoadResponse.Process(data);
        }
    }
}
