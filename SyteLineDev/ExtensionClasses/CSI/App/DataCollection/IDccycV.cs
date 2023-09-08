//PROJECT NAME: DataCollection
//CLASS NAME: IDccycV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccycV
	{
		(int? ReturnCode,
			string Infobar) DccycVSp(
			Guid? DcitemRowPointer,
			int? DcitemTransNum,
			string DcitemItem,
			string DcitemLoc,
			string DcitemWhse,
			decimal? DcitemCountQty,
			string DcitemLot,
			string Infobar);
	}
}

