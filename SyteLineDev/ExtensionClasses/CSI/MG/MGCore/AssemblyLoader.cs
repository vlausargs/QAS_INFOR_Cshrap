using CSI.Data;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.MGCore
{
    public class AssemblyLoader : IAssemblyLoader
    {
        public Assembly GetAssembly(string fullName)
        {
            return IDORuntime.GetMetadataCache().CustomAssemblies.GetAssemblyByFullName(fullName);
        }

        public Type GetType(Assembly assembly, string classFullName)
        {
            if (assembly == null) throw new Exception("Internal Error: assembly is null!");
            if (string.IsNullOrEmpty(classFullName)) throw new Exception("Internal Error: class full name is empty!");
            return assembly.GetType(classFullName);
        }
    }
}
