using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSI.Data
{
    public interface IAssemblyScanner
    {
        IList<Type> LoadRuntimeInterceptClasses(Assembly assembly, Type csiInterfaceType);
        IEnumerable<Type> LoadApplicationClasses(Assembly applicationAssembly, ERuntimeIntercept runtimeIntercept);
        IEnumerable<Type> LoadApplicationInterfaces(Assembly applicationAssembly, ERuntimeIntercept runtimeIntercept);
        IDictionary<Type, IList<Type>> LoadRuntimeInterceptClasses(Assembly applicationAssmelby,Assembly customAssembly, ERuntimeIntercept runtimeIntercept);  
    }
    public class AssemblyScanner : IAssemblyScanner
    {
        readonly IAssemblyLoader assemblyLoader;
        public AssemblyScanner(IAssemblyLoader assemblyLoader)
        {
            this.assemblyLoader = assemblyLoader;
        }

        public IList<Type> LoadRuntimeInterceptClasses(Assembly assembly, Type csiInterfaceType)
        {
            IList<Type> customClasses = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                var implementedInterfaces = type.GetInterfaces().Where(i => i == csiInterfaceType);
                if(implementedInterfaces != null && implementedInterfaces.Count() == 1)
                    customClasses.Add(type);
            }
            return customClasses;
        }

        public IEnumerable<Type> LoadApplicationClasses(Assembly applicationAssembly, ERuntimeIntercept runtimeIntercept)
        {
            IList<Type> types = new List<Type>();
            foreach (Type type in applicationAssembly.GetTypes().Where(c => c.IsClass == true))
            {
                foreach (RuntimeInterceptAttribute attr in type.GetCustomAttributes().
                    Where(a => a is RuntimeInterceptAttribute && ((RuntimeInterceptAttribute)a).ERunTimeIntercept == runtimeIntercept))
                    types.Add(type);
            }
            return types.Distinct();
        }

        public IDictionary<Type, IList<Type>> LoadRuntimeInterceptClasses(Assembly applicationAssmelby, Assembly customAssembly, ERuntimeIntercept runtimeIntercept)
        {
            IDictionary<Type, IList<Type>> ret = new Dictionary<Type, IList<Type>>();
            if (applicationAssmelby == null || customAssembly == null || runtimeIntercept == ERuntimeIntercept.None) return ret;

            foreach (Type applicationInterface in LoadApplicationInterfaces(applicationAssmelby, runtimeIntercept))
            {
                var customClasses = this.LoadRuntimeInterceptClasses(customAssembly, applicationInterface);
                if (customClasses == null || customClasses.Count() == 0) continue;
                ret.Add(applicationInterface, customClasses);
            }
            return ret;
        }
        public IEnumerable<Type> LoadApplicationInterfaces(Assembly applicationAssembly, ERuntimeIntercept runtimeIntercept)
        {
            List<Type> types = new List<Type>();
            foreach (Type type in applicationAssembly.GetTypes().Where(c => c.IsClass == true || c.IsInterface == true))
            {
                foreach (RuntimeInterceptAttribute attr in type.GetCustomAttributes().
                    Where(a => a is RuntimeInterceptAttribute && ((RuntimeInterceptAttribute)a).ERunTimeIntercept == runtimeIntercept))
                {
                    if (type.IsInterface) types.Add(type);
                    else types.AddRange(type.GetInterfaces());
                }
            }
            return types.Distinct();
        }
    }
}
