using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSI.Data
{
    public interface IAssemblyLoader
    {
        Assembly GetAssembly(string AssemblyFullName);
        Type GetType(Assembly assembly, string classFullName);  
    }
}
