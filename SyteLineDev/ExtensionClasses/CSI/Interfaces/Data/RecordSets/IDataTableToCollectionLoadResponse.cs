using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.RecordSets
{
    public interface IDataTableToCollectionLoadResponse
    {
        ICollectionLoadResponse Process(DataTable dataTable);
    }
}
