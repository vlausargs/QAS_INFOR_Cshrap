//PROJECT NAME: DataCollection
//CLASS NAME: IDcAPhysin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAPhysin
	{
		(int? ReturnCode, string Infobar) DcAPhysinSp(string TTermId,
		string TEmpNum,
		DateTime? TTransDate,
		string TItem,
		string TCurWhse,
		string TLocation,
		string TLot,
		decimal? TQty,
		int? PTagNum,
		int? PSheetNum,
		string PEmpCount,
		string PEmpCheck,
		string Infobar);
	}
}

