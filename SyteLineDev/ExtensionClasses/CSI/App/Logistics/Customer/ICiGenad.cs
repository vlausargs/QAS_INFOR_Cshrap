//PROJECT NAME: Logistics
//CLASS NAME: ICiGenad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICiGenad
	{
		(int? ReturnCode, int? NewHdr,
		string Infobar) CiGenadSp(string DoInvoice,
		string DoNum,
		int? DoLine,
		int? DoSeq,
		string CustPo,
		decimal? QtyToInvoice,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		int? NewHdr,
		string Infobar,
		decimal? ShipmentId = null);
	}
}

