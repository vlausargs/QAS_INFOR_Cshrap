//PROJECT NAME: DataCollection
//CLASS NAME: IDcACoship.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcACoship
	{
		(int? ReturnCode, string Infobar) DcACoshipSp(string PTermId,
		int? PTransType,
		string PEmpNum,
		DateTime? TTransDate,
		string PCoNum,
		int? PCoLine,
		int? PCoRel,
		string TItem,
		decimal? Qty,
		string TUm,
		string PLoc,
		string PLot,
		string PCurWhse,
		string PReasonCode,
		string Infobar);
	}
}

