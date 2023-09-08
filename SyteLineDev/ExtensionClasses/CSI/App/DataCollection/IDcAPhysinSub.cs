//PROJECT NAME: DataCollection
//CLASS NAME: IDcAPhysinSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAPhysinSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DcAPhysinSubSp(
			string TTermId,
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
			string PSerNum);
	}
}

