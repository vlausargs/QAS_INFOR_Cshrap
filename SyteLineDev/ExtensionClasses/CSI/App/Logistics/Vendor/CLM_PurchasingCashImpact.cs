//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_PurchasingCashImpact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_PurchasingCashImpact
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchasingCashImpactSp(string Vend_Num = null,
		byte? Detail = (byte)0);
	}
	
	public class CLM_PurchasingCashImpact : ICLM_PurchasingCashImpact
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PurchasingCashImpact(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchasingCashImpactSp(string Vend_Num = null,
		byte? Detail = (byte)0)
		{
			VendNumType _Vend_Num = Vend_Num;
			FlagNyType _Detail = Detail;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_PurchasingCashImpactSp";
				
				appDB.AddCommandParameter(cmd, "Vend_Num", _Vend_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Detail", _Detail, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
