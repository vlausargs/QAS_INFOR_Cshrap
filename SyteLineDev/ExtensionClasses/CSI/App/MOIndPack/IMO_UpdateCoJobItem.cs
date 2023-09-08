//PROJECT NAME: MOIndPack
//CLASS NAME: IMO_UpdateCoJobItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMO_UpdateCoJobItem
	{
		int? MO_UpdateCoJobItemSp(
			string Job,
			int? Suffix,
			int? MOCoJob,
			string Item,
			string MOBomAlternateId,
			decimal? MOQtyPerCycle,
			decimal? QtyReleased,
			string OrdType,
			string OrdNum,
			int? OrdLine,
			int? OrdRelease,
			string RefJob,
			int? RefSuf,
			int? RefOper,
			int? RefSeq,
			string RootJob,
			int? RootSuf,
			string JcbAcct,
			string JcbAcctUnit1,
			string JcbAcctUnit2,
			string JcbAcctUnit3,
			string JcbAcctUnit4,
			string WipAcct,
			string WipAcctUnit1,
			string WipAcctUnit2,
			string WipAcctUnit3,
			string WipAcctUnit4,
			decimal? WipMatlTotal,
			string WipLbrAcct,
			string WipLbrAcctUnit1,
			string WipLbrAcctUnit2,
			string WipLbrAcctUnit3,
			string WipLbrAcctUnit4,
			decimal? WipLbrTotal,
			string WipFovhdAcct,
			string WipFovhdAcctUnit1,
			string WipFovhdAcctUnit2,
			string WipFovhdAcctUnit3,
			string WipFovhdAcctUnit4,
			decimal? WipFovhdTotal,
			string WipVovhdAcct,
			string WipVovhdAcctUnit1,
			string WipVovhdAcctUnit2,
			string WipVovhdAcctUnit3,
			string WipVovhdAcctUnit4,
			decimal? WipVovhdTotal,
			string WipOutAcct,
			string WipOutAcctUnit1,
			string WipOutAcctUnit2,
			string WipOutAcctUnit3,
			string WipOutAcctUnit4,
			decimal? WipOutTotal,
			decimal? WipTotal,
			int? PreassignLots,
			int? PreassignSerials,
			string Description);
	}
}

