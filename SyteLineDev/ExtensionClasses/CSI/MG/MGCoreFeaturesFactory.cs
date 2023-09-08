using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGCoreFeaturesFactory
    {
        public IMongooseDependencies Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            return new MGCoreFeatures(cSIExtensionClassBase);
        }
    }
}
