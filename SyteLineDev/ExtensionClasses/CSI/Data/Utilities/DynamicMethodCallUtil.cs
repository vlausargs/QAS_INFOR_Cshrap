using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSI.Data.Utilities
{
    public class DynamicMethodCallUtil : IDynamicMethodCallUtil
    {
        public object Invoke(string spName, List<object> parmList, object parent)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static |
                                        BindingFlags.NonPublic | BindingFlags.Public;

            bool found = false;
            Type calledType = null;
            FieldInfo[] calledFieldInfos = null;
            FieldInfo[] parentFieldInfos = null;
            List<object> fieldList = new List<object>();
            
            var assemblyArray = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblyArray)
            {
                var types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    var methods = type.GetMethods();

                    foreach (var item in methods)
                    {
                        if (item.Name == spName && !type.Namespace.Contains("CSI.MG") && type.Name[0] != 'I')
                        {
                            calledType = type;
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
                if (found)
                    break;
            }

            calledFieldInfos = calledType.GetFields(bindingFlags);
            parentFieldInfos = parent.GetType().GetFields(bindingFlags);

            foreach (FieldInfo calledfieldInfo in calledFieldInfos)
            {
                foreach (FieldInfo parentfieldInfo in parentFieldInfos)
                {
                    if (calledfieldInfo.FieldType == parentfieldInfo.FieldType &&
                        !fieldList.Contains(parentfieldInfo.GetValue(parent)))
                    {
                       fieldList.Add(parentfieldInfo.GetValue(parent));
                       break;
                    }
                }
            }

            if (fieldList.Count() != calledFieldInfos.Count<FieldInfo>())
            {
                throw new System.InvalidOperationException("Dynamic Method Call Parameters Does Not Match");
            }

            var dynamicObject = Activator.CreateInstance(calledType, fieldList.ToArray());
            MethodInfo method = calledType.GetMethod(spName);
            return method.Invoke(dynamicObject, parmList.ToArray());
        }
    }
}
