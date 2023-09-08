//PROJECT NAME: CSICustomer
//CLASS NAME: PreRmaRepl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPreRmaRepl
	{
		int PreRmaReplSp(string RmaNum,
		                 short? RmaLine,
		                 ref string CoCreditHoldMsg,
		                 ref string CheckCreditMsg,
		                 ref string InfoBar);
	}
	
	public class PreRmaRepl : IPreRmaRepl
	{
		readonly IApplicationDB appDB;
		
		public PreRmaRepl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PreRmaReplSp(string RmaNum,
		                        short? RmaLine,
		                        ref string CoCreditHoldMsg,
		                        ref string CheckCreditMsg,
		                        ref string InfoBar)
		{
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			InfobarType _CoCreditHoldMsg = CoCreditHoldMsg;
			InfobarType _CheckCreditMsg = CheckCreditMsg;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreRmaReplSp";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCreditHoldMsg", _CoCreditHoldMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckCreditMsg", _CheckCreditMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoCreditHoldMsg = _CoCreditHoldMsg;
				CheckCreditMsg = _CheckCreditMsg;
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
