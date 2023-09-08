//PROJECT NAME: POS
//CLASS NAME: SSSPOSEndOfDayProcessing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public interface ISSSPOSEndOfDayProcessing
	{
		(int? ReturnCode, string Infobar) SSSPOSEndOfDayProcessingSp(string CashDrawer = null,
		DateTime? AdjustmentPostingDate = null,
		decimal? EndingCashBalance = 0,
		decimal? EndingCheckBalance = 0,
		byte? CheckInBalance = null,
		byte? CheckInNotBalance = null,
		string Infobar = null);
	}
	
	public class SSSPOSEndOfDayProcessing : ISSSPOSEndOfDayProcessing
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSEndOfDayProcessing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSPOSEndOfDayProcessingSp(string CashDrawer = null,
		DateTime? AdjustmentPostingDate = null,
		decimal? EndingCashBalance = 0,
		decimal? EndingCheckBalance = 0,
		byte? CheckInBalance = null,
		byte? CheckInNotBalance = null,
		string Infobar = null)
		{
			POSMDrawerType _CashDrawer = CashDrawer;
			DateType _AdjustmentPostingDate = AdjustmentPostingDate;
			AmountType _EndingCashBalance = EndingCashBalance;
			AmountType _EndingCheckBalance = EndingCheckBalance;
			ListYesNoType _CheckInBalance = CheckInBalance;
			ListYesNoType _CheckInNotBalance = CheckInNotBalance;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSEndOfDayProcessingSp";
				
				appDB.AddCommandParameter(cmd, "CashDrawer", _CashDrawer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustmentPostingDate", _AdjustmentPostingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCashBalance", _EndingCashBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCheckBalance", _EndingCheckBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckInBalance", _CheckInBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckInNotBalance", _CheckInNotBalance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
