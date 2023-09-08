//PROJECT NAME: Production
//CLASS NAME: PmfPnValidateClose.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnValidateClose
	{
		(int? ReturnCode, string InfoBar, string PromptMsg, string PromptButtons) PmfPnValidateCloseSp(string InfoBar = null,
		                                                                                               Guid? PnRp = null,
		                                                                                               string PromptMsg = null,
		                                                                                               string PromptButtons = null);
	}
	
	public class PmfPnValidateClose : IPmfPnValidateClose
	{
		readonly IApplicationDB appDB;
		
		public PmfPnValidateClose(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, string PromptMsg, string PromptButtons) PmfPnValidateCloseSp(string InfoBar = null,
		                                                                                                      Guid? PnRp = null,
		                                                                                                      string PromptMsg = null,
		                                                                                                      string PromptButtons = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			InfobarType _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnValidateCloseSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, InfoBar, PromptMsg, PromptButtons);
			}
		}
	}
}
