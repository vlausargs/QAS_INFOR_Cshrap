using CSI.MG;
using CSI.Data.CRUD.Triggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadResponse
    {
        /// <summary>
        /// The records fetched during a collection load.  
        /// This collection can be modified and saved back to the database unless restricted from modification during the initial load.
        /// </summary>
        IRecordCollectionWithDeleted Items { get; }

        DataTable ToDataTable();
    }

  
}
