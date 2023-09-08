//PROJECT NAME: Production
//CLASS NAME: IProcessBatchedJobMatlTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IProcessBatchedJobMatlTrans
	{
		(int? ReturnCode, string Infobar) ProcessBatchedJobMatlTransSp(string Site,
		Guid? RowPointer,
		int? ProdBatchId,
		string JobmatlItem,
		int? SerialTracked,
		int? ExtScrap,
		string CurWhse,
		int? ShowBFlushMatls,
		string ContainerNum,
		decimal? ItemQty,
		string Loc,
		string Lot,
		string UM,
		DateTime? TransDate,
		DateTime? RecordDate = null,
		string EmpNum = null,
		string Infobar = null,
		string DocumentNum = null);
	}
}

