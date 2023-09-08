using System;
using System.Data;
using System.Linq;
using CSI.Data.SQL;

namespace CSI.Data.RecordSets
{
    public class RecordCollectionToDataTable : IRecordCollectionToDataTable
    {

        public DataTable ToDataTable(IRecordCollection recordCollection)
        {
            if (recordCollection is RecordCollectionDataTable)
                //take a short cut
                return (recordCollection as RecordCollectionDataTable).TableData;

            var tableData = new DataTable();
            foreach (var column in recordCollection.Columns)
            {
                tableData.Columns.Add(column); //records.Schema[column
                // set column data types
                if (recordCollection.Count > 0 && recordCollection[0] is IRecordInternal)
                {
                    var columnData = ((IRecordInternal)recordCollection[0]).GetValue(column);
                    tableData.Columns[column].DataType = (columnData != null &&columnData != DBNull.Value)? columnData.GetType() : typeof(object);
                }
            }

            tableData.BeginLoadData();
            object[] recordData = new object[recordCollection.Columns.Count()];

            foreach (var record in recordCollection)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                int i = 0;
                foreach (var column in recordCollection.Columns)
                    recordData[i++] = recordInternal.GetValue(column);

                tableData.LoadDataRow(recordData, true);
            }

            tableData.EndLoadData();

            return tableData;
        }
    }
}
