//PROJECT NAME: Data
//CLASS NAME: Pojob3I.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Pojob3I : IPojob3I
	{
		readonly IApplicationDB appDB;
		
		public Pojob3I(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TToLot,
			int? TGetLot,
			string PromptMsg,
			string PromptButtons,
			string Infobar) Pojob3ISp(
			int? ItemLotTracked,
			string JobItem,
			decimal? TMove,
			string TToLot,
			int? TGetLot,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ItemType _JobItem = JobItem;
			QtyUnitType _TMove = TMove;
			LotType _TToLot = TToLot;
			ListYesNoType _TGetLot = TGetLot;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3ISp";
				
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMove", _TMove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TToLot", _TToLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TGetLot", _TGetLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TToLot = _TToLot;
				TGetLot = _TGetLot;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, TToLot, TGetLot, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
