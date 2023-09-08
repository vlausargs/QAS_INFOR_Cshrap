//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckCustomer
	{
		(int? ReturnCode, int? NeedsQC,
		int? HoldCertificateRequired,
		string Messages,
		int? Status,
		string Infobar) RSQC_CheckCustomerSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		string CustNum,
		decimal? QtyToShip,
		string CoitemUM,
		int? NeedsQC,
		int? HoldCertificateRequired,
		string Messages,
		int? Status,
		string Infobar);
	}
}

