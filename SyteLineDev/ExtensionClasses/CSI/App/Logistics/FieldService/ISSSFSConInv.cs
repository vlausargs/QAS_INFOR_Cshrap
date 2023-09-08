//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInv
	{
		(int? ReturnCode, string StartInvNum,
		string EndInvNum,
		string Infobar) SSSFSConInvSp(string StartContract,
		string EndContract,
		int? StartContLine,
		int? EndContLine,
		string StartServType,
		string EndServType,
		string StartCustNum,
		string EndCustNum,
		int? InclAnnually,
		int? InclSemiAnnually,
		int? InclQuarterly,
		int? InclBiMonthly,
		int? InclMonthly,
		int? InclOneTime,
		int? InclElapsedTime,
		string BillFreqList = null,
		DateTime? RenewByDate = null,
		DateTime? InvDate = null,
		int? DisplayFixed = null,
		string CalledFromForm = null,
		string Mode = null,
		Guid? SessionId = null,
		string ContractStatus = null,
		string RequestingUser = null,
		decimal? UserID = null,
		string PartnerId = null,
		string Drawer = null,
		string StartInvNum = null,
		string EndInvNum = null,
		string Infobar = null,
		int? PrintZero = 0);
	}
}

