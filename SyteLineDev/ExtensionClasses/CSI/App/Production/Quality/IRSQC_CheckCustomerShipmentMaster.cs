//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckCustomerShipmentMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckCustomerShipmentMaster
	{
		(int? ReturnCode, int? NeedsQC,
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
		string Infobar);
	}
}

