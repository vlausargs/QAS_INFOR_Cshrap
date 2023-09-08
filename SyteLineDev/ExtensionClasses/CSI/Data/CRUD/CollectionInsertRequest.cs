using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionInsertRequest : ICollectionInsertRequest
    {
        public string IDOName { get; private set; }

        public string TableName { get; }

        public IRecordCollection Items { get; private set; }

        public IReadOnlyDictionary<string, object> ValuesByColumnToAssign { get; }

        public bool CanIDO => Items != null && Items.HasMGItemIDs && !string.IsNullOrWhiteSpace(IDOName);

        public bool CanSQL => !string.IsNullOrWhiteSpace(TableName);

        CollectionInsertRequest(
            string idoName,
            string tableName,
            IRecordCollection items,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign)
        {
            this.IDOName = idoName;
            this.TableName = tableName;
            this.Items = items;
            this.ValuesByColumnToAssign = valuesByColumnToAssign;

            Contract.Requires<ArgumentNullException>(idoName != null || tableName != null, "either IDOName or TableName must be specified");
            Contract.Requires<ArgumentNullException>(ValuesByColumnToAssign != null || items != null, "either valuesByColumnToAssign or items must be specified");
            Contract.Requires<ArgumentNullException>(ValuesByColumnToAssign == null || items == null, "valuesByColumnToAssign and items cannot both be specified");
            Contract.Requires<ArgumentException>(this.CanIDO || this.CanSQL, "the request can't be used for SQL or IDO");
        }

        public ICollectionInsertRequest AddIDOIntercept(string idoName, IRecordCollection items)
        {
            Contract.Requires<ArgumentNullException>(idoName != null, "idoName may not be null");
            Contract.Requires<ArgumentNullException>(items != null, "items may not be null");

            Contract.Requires<ArgumentException>(this.IDOName == null || this.IDOName == idoName, "Incompatible IDO");
            Contract.Requires<ArgumentException>(this.Items == null || this.Items == items, "Incompatible Items");

            this.IDOName = idoName;
            this.Items = items;

            return this;
        }

        public static ICollectionInsertRequest IDOInsert(string idoName, IRecordCollection items)
        {
            return new CollectionInsertRequest(idoName, null, items, null);
        }

        public static ICollectionInsertRequest SQLInsert(string tableName, IRecordCollection items)
        {
            return new CollectionInsertRequest(null, tableName, items, null);
        }

        public static ICollectionInsertRequest SQLInsert(string tableName, IReadOnlyDictionary<string, object> valuesByColumnToAssign)
        {
            return new CollectionInsertRequest(null, tableName, null, valuesByColumnToAssign);
        }
    }
}
