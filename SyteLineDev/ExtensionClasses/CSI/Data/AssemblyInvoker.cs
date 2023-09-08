using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data
{
    public class AssemblyInvoker : IAssemblyInvoker
    {
        public object CreateInstance(Type type, params object[] args)
        {
            if (type == null) throw new Exception("Internal Error: type is null!");
            if (args == null) return System.Activator.CreateInstance(type);
            return System.Activator.CreateInstance(type, args);
        }

        public T Invoke<T>(object classInstance, string methodName, params object[] args)
        {
            if (classInstance == null) throw new Exception("Internal Error: the class instance is null!");
            if (string.IsNullOrEmpty(methodName)) throw new Exception("Internal Error: the method name is empty!");
            Type type = classInstance.GetType();
            var method = type.GetMethod(methodName);
            if (method == null) throw new Exception($"Internal Error: the method {methodName} can't be found in {classInstance.GetType().Name} is empty!");
            return (T)method.Invoke(classInstance, new object[] { });
        }
    }
}
