using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSI.Data.Utilities
{

    public class CollectionLoadResponseUtil : ICollectionLoadResponseUtil
    {
        readonly IRecordCollectionToDataTable recordCollectionToDataTable;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public CollectionLoadResponseUtil(IRecordCollectionToDataTable recordCollectionToDataTable, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.recordCollectionToDataTable = recordCollectionToDataTable;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public ICollectionLoadResponse ExtractRequiredColumns(ICollectionLoadResponse collectionLoadResponse, List<string> requiredColumns)
        {
            var dtTempDataTable = recordCollectionToDataTable.ToDataTable(collectionLoadResponse.Items);

            var extraColumns = new List<string>();

            foreach (DataColumn column in dtTempDataTable.Columns)
                if (!requiredColumns.Contains(column.ColumnName))
                    extraColumns.Add(column.ColumnName);

            foreach (string column in extraColumns)
                dtTempDataTable.Columns.Remove(column);

            var retCollectionLoadResponse = dataTableToCollectionLoadResponse.Process(dtTempDataTable);

            return retCollectionLoadResponse;
        }

        public ICollectionLoadResponse CloneCollectionRenameColumns(ICollectionLoadResponse collectionLoadResponse, List<string> newColumns)
        {
            if (collectionLoadResponse.Items.Columns.Count() != newColumns.Count)
                throw new System.ArgumentException("Error cloning CollectionResponse: Data and new columns should have the same number of elements.");

            var records = new List<Dictionary<string, object>>();
            
            for (int r = 0; r < collectionLoadResponse.Items.Count; r++)
            {
                var record = new Dictionary<string, object>();
                for (int i = 0; i < newColumns.Count; i++)
                {
                    record.Add(newColumns[i], collectionLoadResponse.Items[r].GetValue<object>(i));
                }
                records.Add(record);
            }

            var recordCollection = RecordCollection.Create(newColumns, records) as IRecordCollectionWithDeleted;

            return new SQLCollectionLoadResponse(recordCollection);
        }

        public ICollectionLoadResponse Merge(ICollectionLoadResponse collectionLoadResponse1, ICollectionLoadResponse collectionLoadResponse2, bool distinct = false, string orderBy = "")
        {
            var dataTables = new List<DataTable>();
            var dataTablesCloned = new List<DataTable>();

            if (collectionLoadResponse1 == null)
                return collectionLoadResponse2;

            if (collectionLoadResponse2 == null)
                return collectionLoadResponse1;

            var dataTable1 = recordCollectionToDataTable.ToDataTable(collectionLoadResponse1.Items);
            var dataTable2 = recordCollectionToDataTable.ToDataTable(collectionLoadResponse2.Items);

            dataTables.Add(dataTable1);
            dataTablesCloned.Add(dataTable1.Clone());

            dataTables.Add(dataTable2);
            dataTablesCloned.Add(dataTable2.Clone());

            DataTable outDataTable = new DataTable();
            if (dataTablesCloned.Count > 0)
            {
                outDataTable = dataTablesCloned[0];

                //merge the cloned table columns
                for (int i = 0; i < dataTablesCloned[0].Columns.Count; i++)
                {
                    var type1 = dataTablesCloned[0].Columns[i].DataType;
                    for (int j = 0; j < dataTablesCloned.Count; j++)
                    {
                        dataTables[j].Columns[i].ColumnName = dataTablesCloned[0].Columns[i].ColumnName;
                        Type type2 = dataTablesCloned[j].Columns[i].DataType;
                        type1 = CompareType(type1, type2);
                    }
                    dataTablesCloned[0].Columns[i].DataType = type1;
                }

                //merge the rows of all tables
                foreach (var dt in dataTables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        outDataTable.ImportRow(row);
                    }
                }

                if (!string.IsNullOrEmpty(orderBy))
                {
                    outDataTable.DefaultView.Sort = orderBy;
                }
                outDataTable = outDataTable.DefaultView.ToTable(distinct);
            }

            ICollectionLoadResponse retCollectionLoadResponse = dataTableToCollectionLoadResponse.Process(outDataTable);
            return retCollectionLoadResponse;
        }

        private Type CompareType(Type type1, Type type2)
        {
            var strType1 = type1.Name;
            var strtype2 = type2.Name;
            if (strType1.Contains("Date") || strType1.Contains("Guid") || strType1.Contains("Decimal"))
                return type1;
            if (strtype2.Contains("Date") || strtype2.Contains("Guid") || strtype2.Contains("Decimal"))
                return type2;
            if (strType1.Contains("Int") || strType1.Contains("Byte"))
                return type1;
            if (strtype2.Contains("Int") || strtype2.Contains("Byte"))
                return type2;
            return type1 ?? type2;
        }
    }
}
