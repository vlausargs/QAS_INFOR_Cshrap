//PROJECT NAME: Logistics
//CLASS NAME: PochgP1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PochgP1 : IPochgP1
	{
		readonly IApplicationDB appDB;
		
		
		public PochgP1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PAbort,
		string Infobar,
		string PromptMsg,
		string PromptButtons) PochgP1Sp(string PPoNum,
		string PPoStat,
		int? PAbort,
		string Infobar,
		string PromptMsg,
		string PromptButtons)
		{
			PoNumType _PPoNum = PPoNum;
			PoStatType _PPoStat = PPoStat;
			FlagNyType _PAbort = PAbort;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PochgP1Sp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoStat", _PPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAbort", _PAbort, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAbort = _PAbort;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PAbort, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
