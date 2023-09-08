using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;

namespace CSI.Data.Utilities
{

    public class UnionUtil : IUnionUtil
    {
        private List<ICollectionLoadResponse> LCollectionLoadResponse { get; set; }

        public string OrderBy { get; private set; }

        private UnionType _unionType { get; set; }

        public UnionUtil(UnionType unionType = UnionType.UnionAll, string orderBy = null)
        {
            LCollectionLoadResponse = new List<ICollectionLoadResponse>();
            this._unionType = unionType;
            this.OrderBy = orderBy;
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

        public ICollectionLoadResponse Process()
        {
            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
            var dataTables = new List<DataTable>();
            var dataTablesCloned = new List<DataTable>();

            //init data table list
            for (int j = 0; j < LCollectionLoadResponse.Count; j++)
            {
                var dataTable = recordCollectionToDataTable.ToDataTable(LCollectionLoadResponse[j].Items);
                dataTables.Add(dataTable);
                dataTablesCloned.Add(dataTable.Clone());
            }

            DataTable outDataTable = new DataTable();
            if (dataTablesCloned.Count > 0)
            {
                outDataTable = dataTablesCloned[0];

                //merge the cloned table columns
                for (int i = 0; i < dataTablesCloned[0].Columns.Count; i++)
                {
                    var type1 = dataTablesCloned[0].Columns[i].DataType;
                    var type2 = type1;

                    for (int j = 0; j < dataTablesCloned.Count; j++)
                    {
                        dataTables[j].Columns[i].ColumnName = dataTablesCloned[0].Columns[i].ColumnName;
                        type2 = dataTablesCloned[j].Columns[i].DataType;
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

                if (_unionType.Equals(UnionType.Union))
                {
                    if (!string.IsNullOrEmpty(OrderBy))
                    {
                        outDataTable.DefaultView.Sort = OrderBy;
                    }
                    outDataTable = outDataTable.DefaultView.ToTable(true);
                }
                else
                {
                    if (!string.IsNullOrEmpty(OrderBy))
                    {
                        outDataTable.DefaultView.Sort = OrderBy;
                        outDataTable = outDataTable.DefaultView.ToTable(false);
                    }
                }
            }

            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            ICollectionLoadResponse retCollectionLoadResponse = dataTableToCollectionLoadResponse.Process(outDataTable);
            return retCollectionLoadResponse;
        }

        public void Add(ICollectionLoadResponse iCollectionLoadResponse)
        {
            LCollectionLoadResponse.Add(iCollectionLoadResponse);
        }

        public void Clear()
        {
            this.LCollectionLoadResponse.Clear();
        }

        public ICollectionLoadResponse Process(UnionType unionType, string orderBy)
        {
            _unionType = unionType;
            OrderBy = orderBy;
            return Process();
        }
    }
}
