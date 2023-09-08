//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInv2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInv2
	{
		(int? ReturnCode,
			string InvNum,
			int? InvSeq,
			string InvCred,
			string Infobar) SSSFSConInv2Sp(
			Guid? SessionId,
			string Contract,
			DateTime? RenewByDate,
			DateTime? InvDate,
			string Mode = null,
			string CalledFromForm = null,
			string RequestingUser = null,
			decimal? UserID = null,
			string PartnerId = null,
			string Drawer = null,
			string InvNum = null,
			int? InvSeq = null,
			string InvCred = null,
			string Infobar = null,
			int? PrintZero = 0);
	}
}

