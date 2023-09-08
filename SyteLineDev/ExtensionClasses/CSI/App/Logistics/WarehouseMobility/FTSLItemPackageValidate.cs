//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLItemPackageValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLItemPackageValidate
	{
		int FTSLItemPackageValidateSp(decimal? ShipmentId,
		                              string Item,
		                              ref string ItemDesc,
		                              ref string RefType,
		                              ref decimal? QtyPicked,
		                              ref string SerialTracked,
		                              ref string LotTracked,
		                              ref string ShipmentLine,
		                              ref string ShipmentSeq,
		                              ref string Lot,
		                              ref string Infobar);
	}
	
	public class FTSLItemPackageValidate : IFTSLItemPackageValidate
	{
		readonly IApplicationDB appDB;
		
		public FTSLItemPackageValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLItemPackageValidateSp(decimal? ShipmentId,
		                                     string Item,
		                                     ref string ItemDesc,
		                                     ref string RefType,
		                                     ref decimal? QtyPicked,
		                                     ref string SerialTracked,
		                                     ref string LotTracked,
		                                     ref string ShipmentLine,
		                                     ref string ShipmentSeq,
		                                     ref string Lot,
		                                     ref string Infobar)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			ItemType _Item = Item;
			LongDescType _ItemDesc = ItemDesc;
			RefType _RefType = RefType;
			QtyCumuType _QtyPicked = QtyPicked;
			SerialStatusType _SerialTracked = SerialTracked;
			LotType _LotTracked = LotTracked;
			ItemType _ShipmentLine = ShipmentLine;
			ItemType _ShipmentSeq = ShipmentSeq;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLItemPackageValidateSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyPicked", _QtyPicked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemDesc = _ItemDesc;
				RefType = _RefType;
				QtyPicked = _QtyPicked;
				SerialTracked = _SerialTracked;
				LotTracked = _LotTracked;
				ShipmentLine = _ShipmentLine;
				ShipmentSeq = _ShipmentSeq;
				Lot = _Lot;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
