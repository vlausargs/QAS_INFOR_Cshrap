using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;
using Mongoose.IDO.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGRecordCollection : IRecordCollectionWithDeletedInternal
    {
        IEnumerable<string> columns { get; }
        List<IRecordWithDeleted> data { get; set; }

        List<string> modifiedColumns = new List<string>();

        private MGRecordCollection(IEnumerable<string> columns)
        {
            this.columns = columns;
        }

        public static MGRecordCollection Create(LoadCollectionResponseData data)
        {
            var rc = new MGRecordCollection(data.PropertyList.List);

            List<IRecordWithDeleted> records = new List<IRecordWithDeleted>();
            int index = 0;
            int count = data.Items.Count;
            while (index < count)
                records.Add(new MGRecord(data, index++, rc));

            rc.data = records;

            return rc;
        }

        public bool HasMGItemIDs => true;

        public IEnumerable<string> Columns => columns;

        public int Count => data.Count;

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
