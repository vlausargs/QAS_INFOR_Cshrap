//PROJECT NAME: POS
//CLASS NAME: SSSPOSConInvSubPrtPay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSConInvSubPrtPay : ISSSPOSConInvSubPrtPay
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSConInvSubPrtPay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string tPrintPosmNum,
			decimal? tPrePaidAmount,
			string InfoBar) SSSPOSConInvSubPrtPaySp(
			string tPrintInvNum,
			int? tTransDomCurr,
			string ParmCurrCode,
			string tPrintPosmNum,
			decimal? tPrePaidAmount,
			string InfoBar)
		{
			InvNumType _tPrintInvNum = tPrintInvNum;
			ListYesNoType _tTransDomCurr = tTransDomCurr;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			POSMNumType _tPrintPosmNum = tPrintPosmNum;
			AmountType _tPrePaidAmount = tPrePaidAmount;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSConInvSubPrtPaySp";
				
				appDB.AddCommandParameter(cmd, "tPrintInvNum", _tPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tTransDomCurr", _tTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tPrintPosmNum", _tPrintPosmNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "tPrePaidAmount", _tPrePaidAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				tPrintPosmNum = _tPrintPosmNum;
				tPrePaidAmount = _tPrePaidAmount;
				InfoBar = _InfoBar;
				
				return (Severity, tPrintPosmNum, tPrePaidAmount, InfoBar);
			}
		}
	}
}
