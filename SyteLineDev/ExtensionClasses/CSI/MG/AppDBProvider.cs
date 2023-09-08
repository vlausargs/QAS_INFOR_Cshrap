using Mongoose.IDO.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class AppDBProvider : IAppDBProvider, IDisposable
    {
        readonly CSIExtensionClassBase ecb;
        readonly AppDB appDB = null;
        public AppDBProvider(ICSIExtensionClassBase ecb)
        {
            this.ecb = (CSIExtensionClassBase)ecb;
        }
        
        public AppDB AppDB => appDB ?? ecb.MGAppDB;

        public void Dispose()
        {
            if (appDB != null)
                appDB.Dispose();
        }
    }
}
