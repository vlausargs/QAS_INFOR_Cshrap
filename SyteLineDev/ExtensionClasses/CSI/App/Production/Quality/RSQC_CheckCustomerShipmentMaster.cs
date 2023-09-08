//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCustomerShipmentMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCustomerShipmentMaster : IRSQC_CheckCustomerShipmentMaster
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckCustomerShipmentMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NeedsQC,
		int? HoldCertificateRequired,
		string Messages,
		int? Status,
		string Infobar) RSQC_CheckCustomerShipmentMasterSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		string CoitemUM,
		decimal? ShipmentId,
		int? ShipmentLine,
		decimal? QtyToShip,
		int? NeedsQC,
		int? HoldCertificateRequired,
		string Messages,
		int? Status,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ItemType _Item = Item;
			UMType _CoitemUM = CoitemUM;
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			QtyUnitType _QtyToShip = QtyToShip;
			ListYesNoType _NeedsQC = NeedsQC;
			ListYesNoType _HoldCertificateRequired = HoldCertificateRequired;
			InfobarType _Messages = Messages;
			ListYesNoType _Status = Status;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckCustomerShipmentMasterSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemUM", _CoitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToShip", _QtyToShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NeedsQC", _NeedsQC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HoldCertificateRequired", _HoldCertificateRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Messages", _Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NeedsQC = _NeedsQC;
				HoldCertificateRequired = _HoldCertificateRequired;
				Messages = _Messages;
				Status = _Status;
				Infobar = _Infobar;
				
				return (Severity, NeedsQC, HoldCertificateRequired, Messages, Status, Infobar);
			}
		}
	}
}
