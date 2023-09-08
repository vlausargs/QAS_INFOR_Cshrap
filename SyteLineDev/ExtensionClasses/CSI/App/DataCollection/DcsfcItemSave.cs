//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcItemSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcItemSave : IDcsfcItemSave
	{
		readonly IApplicationDB appDB;
		
		
		public DcsfcItemSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcsfcItemSaveSp(int? TransNum,
		string Item,
		decimal? QtyComplete,
		decimal? QtyMoved,
		decimal? QtyScrapped,
		string Reason,
		int? NextOper,
		string Location,
		string Lot)
		{
			DcTransNumType _TransNum = TransNum;
			ItemType _Item = Item;
			QtyUnitType _QtyComplete = QtyComplete;
			QtyUnitType _QtyMoved = QtyMoved;
			QtyUnitType _QtyScrapped = QtyScrapped;
			ReasonCodeType _Reason = Reason;
			OperNumType _NextOper = NextOper;
			LocType _Location = Location;
			LotType _Lot = Lot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcsfcItemSaveSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reason", _Reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextOper", _NextOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
