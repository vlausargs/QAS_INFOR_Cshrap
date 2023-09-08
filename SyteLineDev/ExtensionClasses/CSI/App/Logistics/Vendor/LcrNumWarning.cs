//PROJECT NAME: CSIVendor
//CLASS NAME: LcrNumWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ILcrNumWarning
	{
		int LcrNumWarningSp(string PLcrNum,
		                    string PVendNum,
		                    string PPoNum,
		                    ref string PromptMsg,
		                    ref string PromptButtons,
		                    ref string Infobar);
	}
	
	public class LcrNumWarning : ILcrNumWarning
	{
		readonly IApplicationDB appDB;
		
		public LcrNumWarning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LcrNumWarningSp(string PLcrNum,
		                           string PVendNum,
		                           string PPoNum,
		                           ref string PromptMsg,
		                           ref string PromptButtons,
		                           ref string Infobar)
		{
			VendLcrNumType _PLcrNum = PLcrNum;
			VendNumType _PVendNum = PVendNum;
			PoNumType _PPoNum = PPoNum;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LcrNumWarningSp";
				
				appDB.AddCommandParameter(cmd, "PLcrNum", _PLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
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
