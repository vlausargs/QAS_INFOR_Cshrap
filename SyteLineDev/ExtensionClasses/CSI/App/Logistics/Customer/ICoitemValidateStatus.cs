//PROJECT NAME: Logistics
//CLASS NAME: ICoitemValidateStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemValidateStatus
	{
		(int? ReturnCode, string Infobar) CoitemValidateStatusSp(string PCoNum,
		int? PCoLine,
		decimal? POldQtyShipped,
		decimal? POldQtyRsvd,
		decimal? POldQtyInvoiced,
		string PCoStat,
		string POldStatus,
		string PNewStatus,
		string Infobar,
		int? PlacesQtyUnit = null);
	}
}

