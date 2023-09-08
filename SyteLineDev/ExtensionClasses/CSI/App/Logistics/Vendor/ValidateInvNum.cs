//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidateInvNum
	{
		int ValidateInvNumSp(string PoNum,
		                     string PoInvNum,
		                     string PoVendNum,
		                     ref string PromptMsg,
		                     ref string PromptButtons);
	}
	
	public class ValidateInvNum : IValidateInvNum
	{
		readonly IApplicationDB appDB;
		
		public ValidateInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateInvNumSp(string PoNum,
		                            string PoInvNum,
		                            string PoVendNum,
		                            ref string PromptMsg,
		                            ref string PromptButtons)
		{
			PoNumType _PoNum = PoNum;
			VendInvNumType _PoInvNum = PoInvNum;
			VendNumType _PoVendNum = PoVendNum;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateInvNumSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoInvNum", _PoInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVendNum", _PoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return Severity;
			}
		}
	}
}
