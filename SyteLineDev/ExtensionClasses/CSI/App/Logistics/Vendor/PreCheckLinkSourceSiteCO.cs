//PROJECT NAME: CSIVendor
//CLASS NAME: PreCheckLinkSourceSiteCO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPreCheckLinkSourceSiteCO
	{
		int PreCheckLinkSourceSiteCOSp(string DemandingPO,
		                               ref string PromptMsg,
		                               ref string PromptButtons,
		                               ref string Infobar);
	}
	
	public class PreCheckLinkSourceSiteCO : IPreCheckLinkSourceSiteCO
	{
		readonly IApplicationDB appDB;
		
		public PreCheckLinkSourceSiteCO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PreCheckLinkSourceSiteCOSp(string DemandingPO,
		                                      ref string PromptMsg,
		                                      ref string PromptButtons,
		                                      ref string Infobar)
		{
			PoNumType _DemandingPO = DemandingPO;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreCheckLinkSourceSiteCOSp";
				
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
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
