using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionDeleteRequest : ICollectionDeleteRequest
    {
        public string IDOName { get; private set; }

        public string TableName { get; }

        public IRecordCollection Items { get; private set; }

        public IReadOnlyDictionary<string, object> ValuesByKeyColumn { get; }

        public bool CanIDO => Items != null && Items.HasMGItemIDs && !string.IsNullOrWhiteSpace(IDOName);

        public bool CanSQL => !string.IsNullOrWhiteSpace(TableName);

        CollectionDeleteRequest(
            string idoName,
            string tableName,
            IRecordCollection items,
            IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            this.IDOName = idoName;
            this.TableName = tableName;
            this.Items = items;
            this.ValuesByKeyColumn = valuesByKeyColumn;

            Contract.Requires<ArgumentNullException>(idoName != null || tableName != null, "at least one of IDOName and TableName must be specified");
            Contract.Requires<ArgumentNullException>(Items != null || ValuesByKeyColumn != null, "at least one of items and valuesByKeyColumn must be specified");
            Contract.Requires<ArgumentNullException>(Items == null || ValuesByKeyColumn == null, "only one of items and valuesByKeyColumn may be specified");
            Contract.Requires<ArgumentException>(this.CanIDO || this.CanSQL, "the request can't be used for SQL or IDO");
        }

        public ICollectionDeleteRequest AddIDOIntercept(string idoName, IRecordCollection items)
        {
            Contract.Requires<ArgumentNullException>(idoName != null, "idoName may not be null");
            Contract.Requires<ArgumentNullException>(items != null, "items may not be null");

            Contract.Requires<ArgumentException>(this.IDOName == null || this.IDOName == idoName, "Incompatible IDO");
            Contract.Requires<ArgumentException>(this.Items == null || this.Items == items, "Incompatible Items");

            this.IDOName = idoName;
            this.Items = items;

            return this;
        }

        public static ICollectionDeleteRequest IDODelete(string idoName, IRecordCollection items)
        {
            return new CollectionDeleteRequest(idoName, null, items, null);
        }

        public static ICollectionDeleteRequest SQLDelete(string tableName, IRecordCollection items)
        {
            return new CollectionDeleteRequest(null, tableName, items, null);
        }

        public static ICollectionDeleteRequest SQLDelete(string tableName, IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            return new CollectionDeleteRequest(null, tableName, null, valuesByKeyColumn);
        }
    }
}
