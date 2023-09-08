using CSI.Data.CRUD;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.RecordSets
{
    public class DataTableToCollectionLoadResponse : IDataTableToCollectionLoadResponse
    {

        public ICollectionLoadResponse Process(DataTable dataTable)
        {
            var recordCollection = new RecordCollectionDataTable(dataTable);
            return new SQLCollectionLoadResponse(recordCollection);
        }
    }
}
