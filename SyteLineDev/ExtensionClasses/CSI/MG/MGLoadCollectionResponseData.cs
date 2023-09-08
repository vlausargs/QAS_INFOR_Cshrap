using CSI.Data.CRUD;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.MG
{
    public class MGLoadCollectionResponseData : IMGLoadCollectionResponseData
    {
        public LoadCollectionResponseData LoadCollectionResponseData { get; private set; }

        public MGLoadCollectionResponseData(LoadCollectionResponseData loadCollectionResponseData)
        {
            this.LoadCollectionResponseData = loadCollectionResponseData;
        }

        public DataTable GetReturnValueDataTable()
        {
            DataTable ret = new DataTable();
            foreach (var item in this.LoadCollectionResponseData.PropertyList.GetArray())
                ret.Columns.Add(item);
            this.LoadCollectionResponseData.Fill(ret);
            return ret;
        }

        public ICollectionLoadResponse GetLoadCollectionResponseData()
        {
            return new MGCollectionLoadResponse(LoadCollectionResponseData);
        }
    }
}
