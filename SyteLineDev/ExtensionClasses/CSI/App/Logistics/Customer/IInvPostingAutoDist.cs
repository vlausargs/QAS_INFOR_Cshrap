//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingAutoDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingAutoDist
	{
		(int? ReturnCode, string Infobar) InvPostingAutoDistSp(Guid? PSessionID,
		string PCustNum,
		string PInvNum,
		int? PInvSeq,
		string Infobar,
		string ToSite = null);
	}
}

