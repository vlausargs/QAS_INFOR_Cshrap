//PROJECT NAME: Logistics
//CLASS NAME: IInvPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPosting
	{
		(int? ReturnCode, int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar) InvPostingSp(Guid? PSessionID,
		string PCustNum,
		string PInvNum,
		int? PInvSeq,
		Guid? PJHeaderRowPointer,
		int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar,
		string ToSite = null,
		string PostSite = null);
	}
}

