using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data
{
    public class AssemblyLoader : IAssemblyLoader
    {
        public Assembly GetAssembly(string AssemblyFullName)
        {
            return System.Reflection.Assembly.Load(AssemblyFullName);
        }

        public Type GetType(Assembly assembly, string classFullName)
        {
            if (assembly == null) throw new Exception("Internal Error: assembly is null!");
            if (string.IsNullOrEmpty(classFullName)) throw new Exception("Internal Error: class full name is empty!");
            return assembly.GetType(classFullName);
        }
    }
}
