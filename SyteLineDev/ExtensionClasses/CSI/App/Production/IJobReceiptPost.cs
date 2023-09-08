//PROJECT NAME: Production
//CLASS NAME: IJobReceiptPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobReceiptPost
	{
		(int? ReturnCode, int? CanOverride,
		string Infobar) JobReceiptPostSp(string Job,
		int? Suffix,
		string Item,
		int? OperNum,
		decimal? Qty,
		string Loc,
		string Lot,
		DateTime? TransDate,
		int? Override,
		int? CanOverride,
		string Infobar,
		string DocumentNum = null,
		string ImportDocId = null,
		string EmpNum = null,
		string ContainerNum = null);
	}
}

