using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSI.Data.CRUD.Triggers;
using System.Data;

namespace CSI.Data.RecordSets
{
    public class RecordCollectionDataTable : IRecordCollectionWithDeletedInternal
    {
        public DataTable TableData { get; }
        IRecordWithDeleted[] deleted { get; }

        List<string> modifiedColumns = new List<string>();

        public RecordCollectionDataTable(DataTable dataTable)
        {
            this.TableData = dataTable;
            this.deleted = new IRecordWithDeleted[dataTable.Rows.Count];
        }

        public bool HasMGItemIDs => false;

        public IEnumerable<string> Columns => TableData.Columns.Cast<DataColumn>().Select(c => c.ColumnName);

        public int Count => TableData.Rows.Count;

        public IRecord this[int recordPosition]
        {
            get
            {
                if (recordPosition < 0 || recordPosition >= this.Count) throw new IndexOutOfRangeException();
                var recordWithDeleted = deleted[recordPosition];
                if (recordWithDeleted != null) return recordWithDeleted;
                var r = TableData.Rows[recordPosition];
                recordWithDeleted = new RecordDataRow(r, this) as IRecordWithDeleted;
                deleted[recordPosition] = recordWithDeleted;
                return recordWithDeleted;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public IEnumerator<IRecord> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
                yield return this[i];
        }

        public bool IsUpdated(string columnName)
        {
            return modifiedColumns.Contains(columnName);
        }

        IRecordWithDeleted IRecordCollectionWithDeleted.this[int recordPostion] => (IRecordWithDeleted)this[recordPostion];

        void IRecordCollectionWithDeletedInternal.SetColumnModified(string columnName)
        {
            if (Columns.Contains(columnName))
            {
                if (modifiedColumns.Contains(columnName))
                    return;
                modifiedColumns.Add(columnName);
            }
        }
    }
}
