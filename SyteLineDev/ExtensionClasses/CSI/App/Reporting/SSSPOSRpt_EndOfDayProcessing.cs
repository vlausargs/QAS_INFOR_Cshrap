//PROJECT NAME: Reporting
//CLASS NAME: SSSPOSRpt_EndOfDayProcessing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSPOSRpt_EndOfDayProcessing : ISSSPOSRpt_EndOfDayProcessing
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSPOSRpt_EndOfDayProcessing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_EndOfDayProcessingSp(string CashDrawer = null,
		DateTime? AdjustmentPostingDate = null,
		decimal? EndingCashBalance = 0.00M,
		decimal? EndingCheckBalance = 0.00M,
		int? CheckInBalance = null,
		int? CheckInNotBalance = null,
		string pSite = null)
		{
			POSMDrawerType _CashDrawer = CashDrawer;
			DateType _AdjustmentPostingDate = AdjustmentPostingDate;
			AmountType _EndingCashBalance = EndingCashBalance;
			AmountType _EndingCheckBalance = EndingCheckBalance;
			ListYesNoType _CheckInBalance = CheckInBalance;
			ListYesNoType _CheckInNotBalance = CheckInNotBalance;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSRpt_EndOfDayProcessingSp";
				
				appDB.AddCommandParameter(cmd, "CashDrawer", _CashDrawer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustmentPostingDate", _AdjustmentPostingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCashBalance", _EndingCashBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCheckBalance", _EndingCheckBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckInBalance", _CheckInBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckInNotBalance", _CheckInNotBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
