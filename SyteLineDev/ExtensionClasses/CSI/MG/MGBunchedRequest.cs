using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mongoose.IDO.Protocol;
using CSI.Data.Cache;

namespace CSI.MG
{
    public class MGBunchedRequest : IMGBunchedRequest
    {
        readonly LoadCollectionDataBase loadCollectionDataBase;
        readonly ILoadCollectionDataBaseProvider provider;
        public MGBunchedRequest(ILoadCollectionDataBaseProvider provider)
        {
            this.provider = provider;
        }
        [Obsolete("Use the other constuctor. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        public MGBunchedRequest(LoadCollectionDataBase loadCollectionDataBase)
        {
            this.loadCollectionDataBase = loadCollectionDataBase;
        }
        private LoadCollectionDataBase LoadCollectionDataBase
        {
            get
            {
                if (this.loadCollectionDataBase != null) return this.loadCollectionDataBase;
                return provider?.LoadCollectionDataBase;
            }
        }
        public bool EnableBookmark
        {
            get
            {
                return LoadCollectionDataBase?.EnableBookmark ?? false;
            }
            set
            {
                if (LoadCollectionDataBase != null)
                    LoadCollectionDataBase.EnableBookmark = value;
            }
        }

        public string Bookmark
        {
            get
            {
                return LoadCollectionDataBase?.Bookmark ?? "";
            }
            set
            {
                if(LoadCollectionDataBase != null)
                    LoadCollectionDataBase.Bookmark = value;
            }
        }

        public int RecordCap
        {
            get
            {
                return LoadCollectionDataBase?.RecordCap ?? 0;
            }
            set
            {
                if (LoadCollectionDataBase != null)
                    LoadCollectionDataBase.RecordCap = value;
            }
        }

        public LoadType LoadType
        {
            get
            {
                if (LoadCollectionDataBase == null) return LoadType.First;
                return LoadCollectionDataBase.LoadType == LoadCollectionType.Next ? LoadType.Next : LoadType.First;
            }
        }
    }
}
