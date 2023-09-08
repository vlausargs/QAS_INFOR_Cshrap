//PROJECT NAME: Material
//CLASS NAME: ICLM_LotForTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_LotForTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LotForTransSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		DateTime? TransDate,
		string Whse,
		string LocType,
		string Loc,
		int? ReceiptFlag = 1);
	}
}

