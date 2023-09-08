using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data
{
    public interface IAssemblyInvoker
    {
        object CreateInstance(Type type, params object[] args);
        T Invoke<T>(object classInstance, string methodName, params object[] args);
    }
}
