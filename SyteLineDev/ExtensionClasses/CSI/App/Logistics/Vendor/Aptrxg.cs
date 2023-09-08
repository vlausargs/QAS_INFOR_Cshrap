//PROJECT NAME: Logistics
//CLASS NAME: Aptrxg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Aptrxg : IAptrxg
	{
		readonly IApplicationDB appDB;
		
		
		public Aptrxg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RCheck1,
		decimal? RSalesTax1,
		int? RCheck2,
		decimal? RSalesTax2,
		string PromptMsg,
		string PromptButtons,
		string Infobar) AptrxgSp(int? PAskFlag,
		Guid? PRecidAptrx,
		int? RCheck1,
		decimal? RSalesTax1,
		int? RCheck2,
		decimal? RSalesTax2,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			ListYesNoType _PAskFlag = PAskFlag;
			RowPointerType _PRecidAptrx = PRecidAptrx;
			ListYesNoType _RCheck1 = RCheck1;
			GenericDecimalType _RSalesTax1 = RSalesTax1;
			ListYesNoType _RCheck2 = RCheck2;
			GenericDecimalType _RSalesTax2 = RSalesTax2;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AptrxgSp";
				
				appDB.AddCommandParameter(cmd, "PAskFlag", _PAskFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecidAptrx", _PRecidAptrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RCheck1", _RCheck1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RSalesTax1", _RSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCheck2", _RCheck2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RSalesTax2", _RSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RCheck1 = _RCheck1;
				RSalesTax1 = _RSalesTax1;
				RCheck2 = _RCheck2;
				RSalesTax2 = _RSalesTax2;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, RCheck1, RSalesTax1, RCheck2, RSalesTax2, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
