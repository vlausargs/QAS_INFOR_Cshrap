//PROJECT NAME: Finance
//CLASS NAME: ExtFin_GetArinvdDetailByTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Finance.ExtFin
{
	public class ExtFin_GetArinvdDetailByTaxCode : IExtFin_GetArinvdDetailByTaxCode
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public ExtFin_GetArinvdDetailByTaxCode(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse ExtFin_GetArinvdDetailByTaxCodeFn(
			decimal? Batch)
		{
			OperationCounterType _Batch = Batch;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[ExtFin_GetArinvdDetailByTaxCode](@Batch)";
				
				appDB.AddCommandParameter(cmd, "Batch", _Batch, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_ExtFin_GetArinvdDetailByTaxCode";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
