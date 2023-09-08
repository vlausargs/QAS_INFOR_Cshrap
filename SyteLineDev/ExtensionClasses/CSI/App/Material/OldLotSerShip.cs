//PROJECT NAME: Material
//CLASS NAME: OldLotSerShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class OldLotSerShip : IOldLotSerShip
	{
		readonly IApplicationDB appDB;
		
		
		public OldLotSerShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) OldLotSerShipSp(decimal? RefId,
		string RefType = null,
		Guid? ProcessId = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			DecimalType _RefId = RefId;
			StringType _RefType = RefType;
			RowPointerType _ProcessId = ProcessId;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "OldLotSerShipSp";
				
				appDB.AddCommandParameter(cmd, "RefId", _RefId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
