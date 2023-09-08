//PROJECT NAME: Data
//CLASS NAME: PochgP2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PochgP2 : IPochgP2
	{
		readonly IApplicationDB appDB;
		
		public PochgP2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PPoChange,
			string Infobar,
			string PromptMsg,
			string PromptButtons) PochgP2Sp(
			string PPoNum,
			string PPoStat,
			int? PPoChange,
			string Infobar,
			string PromptMsg,
			string PromptButtons)
		{
			PoNumType _PPoNum = PPoNum;
			PoStatType _PPoStat = PPoStat;
			FlagNyType _PPoChange = PPoChange;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PochgP2Sp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoStat", _PPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoChange", _PPoChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPoChange = _PPoChange;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PPoChange, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
