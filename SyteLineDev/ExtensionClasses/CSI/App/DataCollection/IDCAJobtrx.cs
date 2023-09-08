//PROJECT NAME: DataCollection
//CLASS NAME: IDCAJobtrx.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDCAJobtrx
	{
		(int? ReturnCode, string Infobar) DCAJobtrxSp(string PEmpNum,
		DateTime? PDate,
		int? PTime,
		string PTermid,
		string PTransType,
		string PJob,
		int? PSuffix,
		int? POperNum,
		string PIndCode,
		decimal? PQtyComplete,
		decimal? PQtyScrapped,
		int? PCompleteOp,
		string PLoc,
		string PLot,
		decimal? PQtyMoved,
		string PReasonCode,
		string PWc,
		string Machine,
		string Infobar);
	}
}

