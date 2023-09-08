//PROJECT NAME: POS
//CLASS NAME: SSSPOSRpt_PosIncCr2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSRpt_PosIncCr2 : ISSSPOSRpt_PosIncCr2
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSRpt_PosIncCr2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSPOSRpt_PosIncCr2Sp(
			string tPrintInvNum,
			string tPrintPosmNum,
			int? tTransDomCurr,
			string ParmCurrCode)
		{
			InvNumType _tPrintInvNum = tPrintInvNum;
			POSMNumType _tPrintPosmNum = tPrintPosmNum;
			ListYesNoType _tTransDomCurr = tTransDomCurr;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSRpt_PosIncCr2Sp";
				
				appDB.AddCommandParameter(cmd, "tPrintInvNum", _tPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tPrintPosmNum", _tPrintPosmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tTransDomCurr", _tTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
