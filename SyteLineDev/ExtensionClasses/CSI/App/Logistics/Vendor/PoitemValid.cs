//PROJECT NAME: Logistics
//CLASS NAME: PoitemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoitemValid : IPoitemValid
	{
		readonly IApplicationDB appDB;
		
		
		public PoitemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string ItemDesc,
		int? SerialTracked,
		int? LotTracked,
		decimal? QtyOrdered,
		decimal? QtyReceived,
		int? EnableContainer,
		string Infobar,
		string Whse) PoitemValidSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string Item,
		string ItemDesc,
		int? SerialTracked,
		int? LotTracked,
		decimal? QtyOrdered,
		decimal? QtyReceived,
		int? EnableContainer,
		string Infobar,
		string Whse)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _LotTracked = LotTracked;
			QtyUnitNoNegType _QtyOrdered = QtyOrdered;
			QtyUnitNoNegType _QtyReceived = QtyReceived;
			ListYesNoType _EnableContainer = EnableContainer;
			InfobarType _Infobar = Infobar;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoitemValidSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableContainer", _EnableContainer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				ItemDesc = _ItemDesc;
				SerialTracked = _SerialTracked;
				LotTracked = _LotTracked;
				QtyOrdered = _QtyOrdered;
				QtyReceived = _QtyReceived;
				EnableContainer = _EnableContainer;
				Infobar = _Infobar;
				Whse = _Whse;
				
				return (Severity, Item, ItemDesc, SerialTracked, LotTracked, QtyOrdered, QtyReceived, EnableContainer, Infobar, Whse);
			}
		}
	}
}
