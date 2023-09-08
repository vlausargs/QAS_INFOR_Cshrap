using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class LoadCollectionDataBaseProvider : ILoadCollectionDataBaseProvider
    {
        readonly CSIExtensionClassBase ecb;
        LoadCollectionDataBase _LoadCollectionDataBase;
        public LoadCollectionDataBaseProvider(ICSIExtensionClassBase ecb)
        {
            this.ecb = (CSIExtensionClassBase)ecb;
        }
        public LoadCollectionDataBase LoadCollectionDataBase
        {
            get
            {
                if (_LoadCollectionDataBase == null)
                    _LoadCollectionDataBase = (LoadCollectionDataBase)ecb.Context.Request;
                return _LoadCollectionDataBase;
            }
        }
    }
}
