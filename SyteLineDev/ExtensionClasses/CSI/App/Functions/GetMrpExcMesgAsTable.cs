using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Functions
{
    public class GetMrpExcMesgAsTable : IGetMrpExcMesgAsTable
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public GetMrpExcMesgAsTable(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

        public ICollectionLoadResponse GetMrpExcMesgAsTableFn(string item, string MrpOrderType, string ApsOrder, int? MrpOrderLine, int MrpOrderRelease, Guid? RowPointer)
        {
			ItemType _item = item;
			MrpOrderTypeType _MrpOrderType = MrpOrderType;
			ApsOrderType _ApsOrder = ApsOrder;
			MrpOrderLineType _MrpOrderLine = MrpOrderLine;
			MrpOrderReleaseType _MrpOrderRelease = MrpOrderRelease;
			RowPointerType _RowPointer = RowPointer;

			using (IDbCommand cmd = appDB.CreateCommand())
            {
				cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dbo.[GetMrpExcMesgAsTable](@item, @MrpOrderType, @ApsOrder, @MrpOrderLine, @MrpOrderRelease, @RowPointer)";

				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpOrderType", _MrpOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsOrder", _ApsOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpOrderLine", _MrpOrderLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpOrderRelease", _MrpOrderRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);

				DataTable dtReturn  = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetMrpExcMesgAsTable";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
    }
}
