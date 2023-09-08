//PROJECT NAME: CSICustomer
//CLASS NAME: LcrExpDateWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ILcrExpDateWarning
	{
		int LcrExpDateWarningSp(string CoNum,
		                        string CustNum,
		                        string LcrNum,
		                        ref string PromptMsg,
		                        ref string PromptButtons,
		                        ref string Infobar);
	}
	
	public class LcrExpDateWarning : ILcrExpDateWarning
	{
		readonly IApplicationDB appDB;
		
		public LcrExpDateWarning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LcrExpDateWarningSp(string CoNum,
		                               string CustNum,
		                               string LcrNum,
		                               ref string PromptMsg,
		                               ref string PromptButtons,
		                               ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			LcrNumType _LcrNum = LcrNum;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LcrExpDateWarningSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrNum", _LcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
