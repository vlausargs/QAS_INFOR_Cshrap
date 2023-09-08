using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using Mongoose.IDO.Protocol;
using System.Data;

namespace CSI.MG
{
    public class MGCollectionLoadResponse : ICollectionLoadResponse
    {
        LoadCollectionResponseData loadCollectionResponseData;
        public MGCollectionLoadResponse(LoadCollectionResponseData loadCollectionResponseData)
        {
            this.loadCollectionResponseData = loadCollectionResponseData;
        }

        public IRecordCollectionWithDeleted Items
        {
            get
            {
                return MGRecordCollection.Create(loadCollectionResponseData);
            }
        }

        public DataTable ToDataTable()
        {
            var tableData = new DataTable();
            loadCollectionResponseData.Fill(tableData);

            return tableData;
        }
    }
}
