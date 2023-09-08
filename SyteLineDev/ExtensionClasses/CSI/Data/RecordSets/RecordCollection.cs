using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.RecordSets
{
    public class RecordCollection : IRecordCollectionWithDeletedInternal
    {
        IEnumerable<string> columns { get; }
        List<IRecordWithDeleted> data { get; set; }

        List<string> modifiedColumns = new List<string>();

        RecordCollection(IEnumerable<string> columns)
        {
            this.columns = columns;
        }

        public static RecordCollection Create(IEnumerable<string> columns, List<Dictionary<string, object>> data)
        {
            var rc = new RecordCollection(columns);

            IDataConverter dataConverter = new DataConverter();

            var records = data.Select(r => new Record(r, rc, dataConverter) as IRecordWithDeleted).ToList();

            rc.data = records;

            return rc;
        }

        public bool HasMGItemIDs => false;

        public IEnumerable<string> Columns => columns;

        public int Count => data.Count();

        public IRecord this[int recordPostion] => data[recordPostion];

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public IEnumerator<IRecord> GetEnumerator()
        {
            foreach (var r in data)
                yield return r;
        }

        public bool IsUpdated(string columnName)
        {
            return modifiedColumns.Contains(columnName);
        }

        IRecordWithDeleted IRecordCollectionWithDeleted.this[int recordPostion] => data[recordPostion];

        void IRecordCollectionWithDeletedInternal.SetColumnModified(string columnName)
        {
            if (modifiedColumns.Contains(columnName))
                return;
            modifiedColumns.Add(columnName);
        }
    }
}