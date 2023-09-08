//PROJECT NAME: CSIMaterial
//CLASS NAME: CountQtyValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ICountQtyValidate
	{
		int CountQtyValidateSp(string Whse,
		                       string Loc,
		                       string Item,
		                       string Lot,
		                       string SerNum,
		                       decimal? QtyCount,
		                       ref string PromptMsg,
		                       ref string PromptButtons);
	}
	
	public class CountQtyValidate : ICountQtyValidate
	{
		readonly IApplicationDB appDB;
		
		public CountQtyValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CountQtyValidateSp(string Whse,
		                              string Loc,
		                              string Item,
		                              string Lot,
		                              string SerNum,
		                              decimal? QtyCount,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ItemType _Item = Item;
			LotType _Lot = Lot;
			SerNumType _SerNum = SerNum;
			QtyUnitNoNegType _QtyCount = QtyCount;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CountQtyValidateSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyCount", _QtyCount, ParameterDirection.Input);
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
