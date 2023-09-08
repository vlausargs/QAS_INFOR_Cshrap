using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;
using System;
using System.Data;
using System.Linq;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadResponse : ICollectionLoadResponse
    {
        IRecordCollectionWithDeleted data { get; }

        public SQLCollectionLoadResponse(IRecordCollectionWithDeleted data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IRecordCollectionWithDeleted Items => data;

        public DataTable ToDataTable()
        {
            if (Items is RecordCollectionDataTable)
                //take a short cut
                return (Items as RecordCollectionDataTable).TableData;

            var tableData = new DataTable();
            foreach (var column in Items.Columns)
            {
                tableData.Columns.Add(column);
                // set column data types
                if (Items.Count > 0 && Items[0] is IRecordInternal)
                {
                    var columnData = ((IRecordInternal)Items[0]).GetValue(column);
                    tableData.Columns[column].DataType = (columnData != null && columnData != DBNull.Value) ? columnData.GetType() : typeof(object);
                }
            }

            tableData.BeginLoadData();
            object[] recordData = new object[Items.Columns.Count()];

            foreach (var record in Items)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                int i = 0;
                foreach (var column in Items.Columns)
                    recordData[i++] = recordInternal.GetValue(column);

                tableData.LoadDataRow(recordData, true);
            }

            tableData.EndLoadData();

            return tableData;
        }
    }
}
