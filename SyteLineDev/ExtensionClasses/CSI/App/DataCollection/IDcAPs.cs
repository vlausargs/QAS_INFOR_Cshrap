//PROJECT NAME: DataCollection
//CLASS NAME: IDcAPs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAPs
	{
		(int? ReturnCode, string Infobar) DcAPsSp(string TermId,
		string PTransType,
		string EmpNum,
		DateTime? TTransDate,
		string PsItem,
		string PsNum,
		string Wc,
		int? OperNum,
		decimal? Qty,
		string Loc,
		string Lot,
		string Infobar);
	}
}

