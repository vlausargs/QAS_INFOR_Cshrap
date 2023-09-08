//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBInventoryCountPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBInventoryCountPost : ILoadESBInventoryCountPost
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBInventoryCountPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) LoadESBInventoryCountPostSp(string BODNOUN,
		string DocumentID,
		string Item,
		string Warehouse,
		string SerializedLotID,
		DateTime? SerializedLotExpDate,
		decimal? Qty,
		string ISOUM,
		string HoldCode,
		decimal? CountSequence,
		int? LineNumber,
		DateTime? TransDate,
		string ReasonCode,
		string InfoBar)
		{
			StringType _BODNOUN = BODNOUN;
			StringType _DocumentID = DocumentID;
			ItemType _Item = Item;
			StringType _Warehouse = Warehouse;
			StringType _SerializedLotID = SerializedLotID;
			DateType _SerializedLotExpDate = SerializedLotExpDate;
			QtyUnitType _Qty = Qty;
			UMType _ISOUM = ISOUM;
			StringType _HoldCode = HoldCode;
			CountSequenceType _CountSequence = CountSequence;
			IntType _LineNumber = LineNumber;
			DateType _TransDate = TransDate;
			StringType _ReasonCode = ReasonCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBInventoryCountPostSp";
				
				appDB.AddCommandParameter(cmd, "BODNOUN", _BODNOUN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Warehouse", _Warehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerializedLotID", _SerializedLotID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerializedLotExpDate", _SerializedLotExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOUM", _ISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldCode", _HoldCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountSequence", _CountSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
