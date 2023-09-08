//PROJECT NAME: Material
//CLASS NAME: MrpWbGetPoInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbGetPoInfo : IMrpWbGetPoInfo
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbGetPoInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string VendNum,
		decimal? BlanketUnitCost,
		int? IsBlanket,
		string Infobar,
		string Whse) MrpWbGetPoInfoSp(string PoNum,
		DateTime? DueDate,
		string Item,
		string VendNum,
		decimal? BlanketUnitCost,
		int? IsBlanket,
		string Infobar,
		string Whse)
		{
			PoNumType _PoNum = PoNum;
			DateType _DueDate = DueDate;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			CostPrcType _BlanketUnitCost = BlanketUnitCost;
			ListYesNoType _IsBlanket = IsBlanket;
			InfobarType _Infobar = Infobar;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbGetPoInfoSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BlanketUnitCost", _BlanketUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsBlanket", _IsBlanket, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VendNum = _VendNum;
				BlanketUnitCost = _BlanketUnitCost;
				IsBlanket = _IsBlanket;
				Infobar = _Infobar;
				Whse = _Whse;
				
				return (Severity, VendNum, BlanketUnitCost, IsBlanket, Infobar, Whse);
			}
		}
	}
}
