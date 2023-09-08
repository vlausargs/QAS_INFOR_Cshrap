//PROJECT NAME: Production
//CLASS NAME: IProcessJobMatlTransSetVars.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IProcessJobMatlTransSetVars
	{
		(int? ReturnCode, string Infobar) ProcessJobMatlTransSetVarsSp(string SET,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		int? DeleteTmpSer = 0,
		int? Backflush = 0,
		int? ByProduct = 0,
		string UM = null,
		string Item = null,
		string Description = null,
		string Wc = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		DateTime? TransDate = null,
		decimal? MatlCost = null,
		decimal? LbrCost = null,
		decimal? FovhdCost = null,
		decimal? VovhdCost = null,
		decimal? OutCost = null,
		decimal? Cost = null,
		decimal? PlanCost = null,
		decimal? Qty = null,
		string Acct = null,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null,
		Guid? RowPointer = null,
		string JobmatlRefType = null,
		string JobmatlRefNum = null,
		int? JobmatlRefLineSuf = null,
		int? JobmatlRefRelease = null,
		string Infobar = null,
		string ImportDocId = null,
		string JobLot = null,
		string JobSerial = null,
		string ContainerNum = null,
		DateTime? RecordDate = null,
		string EmpNum = null,
		string DocumentNum = null);
	}
}

