using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionUpdateRequest : ICollectionUpdateRequest
    {
        public string IDOName { get; private set; }

        public string TableName { get; }

        public IRecordCollectionWithDeleted Items { get; private set; }

        public IReadOnlyDictionary<string, object> ValuesByColumnToAssign { get; }

        public IReadOnlyDictionary<string, object> ValuesByKeyColumn { get; }

        public bool CanIDO => this.Items != null && Items.HasMGItemIDs && !string.IsNullOrWhiteSpace(IDOName);

        public bool CanSQL => !string.IsNullOrWhiteSpace(TableName);

        CollectionUpdateRequest(
            string idoName, 
            string tableName,
            IRecordCollectionWithDeleted items, 
            IReadOnlyDictionary<string, object> valuesByColumnToAssign,
            IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            this.IDOName = idoName;
            this.TableName = tableName;
            this.Items = items;
            this.ValuesByColumnToAssign = valuesByColumnToAssign;
            this.ValuesByKeyColumn = valuesByKeyColumn;

            Contract.Requires<ArgumentNullException>(idoName != null || tableName != null, "at least one of IDOName and TableName must be specified");
            Contract.Requires<ArgumentNullException>(valuesByColumnToAssign == null || items == null, "valuesByColumnToAssign and items cannot both be specified");
            Contract.Requires<ArgumentNullException>((valuesByColumnToAssign == null && ValuesByKeyColumn == null) || (valuesByColumnToAssign != null && ValuesByKeyColumn != null), "valuesByColumnToAssign and valuesByKeyColumn must both be specified or not");
            Contract.Requires<ArgumentException>(this.CanIDO || this.CanSQL, "the request can't be used for SQL or IDO");
        }

        public ICollectionUpdateRequest AddIDOIntercept(string idoName, IRecordCollectionWithDeleted items)
        {
            Contract.Requires<ArgumentNullException>(idoName != null, "idoName may not be null");
            Contract.Requires<ArgumentNullException>(items != null, "items may not be null");

            Contract.Requires<ArgumentException>(this.IDOName == null || this.IDOName == idoName, "Incompatible IDO");
            Contract.Requires<ArgumentException>(this.Items == null || this.Items == items, "Incompatible Items");

            this.IDOName = idoName;
            this.Items = items;

            return this;
        }

        public static ICollectionUpdateRequest IDOUpdate(string idoName, IRecordCollectionWithDeleted items)
        {
            return new CollectionUpdateRequest(idoName, null, items, null, null);
        }

        public static ICollectionUpdateRequest SQLUpdate(string tableName, IRecordCollectionWithDeleted items)
        {
            return new CollectionUpdateRequest(null, tableName, items, null, null);
        }

        public static ICollectionUpdateRequest SQLUpdate(
            string tableName, 
            IReadOnlyDictionary<string, object> valuesByColumnToAssign,
            IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            return new CollectionUpdateRequest(null, tableName, null, valuesByColumnToAssign, valuesByKeyColumn);
        }
    }
}
