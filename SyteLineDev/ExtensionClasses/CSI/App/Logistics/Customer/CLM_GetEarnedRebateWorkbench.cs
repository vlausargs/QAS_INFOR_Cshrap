//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetEarnedRebateWorkbench.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetEarnedRebateWorkbench
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_GetEarnedRebateWorkbenchSp(string PromotionCode,
		DateTime? ApplicationDate = null,
		string EarnedRebateStatusString = "P",
		string CustNum = null,
		string InfoBar = null,
		string FilterString = null);
	}
	
	public class CLM_GetEarnedRebateWorkbench : ICLM_GetEarnedRebateWorkbench
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetEarnedRebateWorkbench(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_GetEarnedRebateWorkbenchSp(string PromotionCode,
		DateTime? ApplicationDate = null,
		string EarnedRebateStatusString = "P",
		string CustNum = null,
		string InfoBar = null,
		string FilterString = null)
		{
			PromotionCodeType _PromotionCode = PromotionCode;
			DateType _ApplicationDate = ApplicationDate;
			EarnedRebateStatusType _EarnedRebateStatusString = EarnedRebateStatusString;
			CustNumType _CustNum = CustNum;
			InfobarType _InfoBar = InfoBar;
			LongListType _FilterString = FilterString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetEarnedRebateWorkbenchSp";
				
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplicationDate", _ApplicationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarnedRebateStatusString", _EarnedRebateStatusString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                InfoBar = _InfoBar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
			}
		}
	}
}
