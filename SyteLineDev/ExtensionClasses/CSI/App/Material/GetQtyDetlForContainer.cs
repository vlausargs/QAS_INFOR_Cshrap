//PROJECT NAME: Material
//CLASS NAME: GetQtyDetlForContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetQtyDetlForContainer : IGetQtyDetlForContainer
	{
		readonly IApplicationDB appDB;
		
		
		public GetQtyDetlForContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TotalQtyContained,
		decimal? OtherQtyContained,
		decimal? QtyOnHand,
		decimal? QtyRvsd,
		decimal? ForUseQtyContained,
		decimal? QtyContained,
		string Infobar) GetQtyDetlForContainerSp(string ContainNum,
		string Whse,
		string Loc,
		string Item,
		string Lot,
		decimal? TotalQtyContained,
		decimal? OtherQtyContained,
		decimal? QtyOnHand,
		decimal? QtyRvsd,
		decimal? ForUseQtyContained,
		decimal? QtyContained,
		string Infobar)
		{
			ContainerNumType _ContainNum = ContainNum;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ItemType _Item = Item;
			LotType _Lot = Lot;
			QtyUnitNoNegType _TotalQtyContained = TotalQtyContained;
			QtyUnitNoNegType _OtherQtyContained = OtherQtyContained;
			QtyTotlType _QtyOnHand = QtyOnHand;
			QtyTotlType _QtyRvsd = QtyRvsd;
			QtyUnitNoNegType _ForUseQtyContained = ForUseQtyContained;
			QtyUnitNoNegType _QtyContained = QtyContained;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetQtyDetlForContainerSp";
				
				appDB.AddCommandParameter(cmd, "ContainNum", _ContainNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalQtyContained", _TotalQtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OtherQtyContained", _OtherQtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRvsd", _QtyRvsd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForUseQtyContained", _ForUseQtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyContained", _QtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotalQtyContained = _TotalQtyContained;
				OtherQtyContained = _OtherQtyContained;
				QtyOnHand = _QtyOnHand;
				QtyRvsd = _QtyRvsd;
				ForUseQtyContained = _ForUseQtyContained;
				QtyContained = _QtyContained;
				Infobar = _Infobar;
				
				return (Severity, TotalQtyContained, OtherQtyContained, QtyOnHand, QtyRvsd, ForUseQtyContained, QtyContained, Infobar);
			}
		}
	}
}
