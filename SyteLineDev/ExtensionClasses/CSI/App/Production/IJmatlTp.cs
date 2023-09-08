//PROJECT NAME: Production
//CLASS NAME: IJmatlTp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJmatlTp
	{
		(int? ReturnCode, string Infobar) JmatlTpSp(string CallFrom,
		int? DeleteTmpSer,
		int? Backflush,
		string Workkey,
		int? ByProduct,
		string TransClass,
		string JobJob,
		int? JobSuffix,
		int? JobmatlOperNum,
		decimal? JobmatlSequence,
		string ChildItem,
		string Wc,
		string EmpNum,
		string Whse,
		string Loc,
		string Lot,
		DateTime? TransDate,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? Cost,
		decimal? Qty,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string ImportDocId = null,
		string Infobar = null,
		string JobLot = null,
		string JobSerial = null,
		string ContainerNum = null,
		string DocumentNum = null);
	}
}

