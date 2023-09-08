//PROJECT NAME: DataCollection
//CLASS NAME: IDcAMiscirSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAMiscirSub
	{
		int? DcAMiscirSubSp(
			string TTermId,
			string pEmpNum,
			DateTime? TTransDate,
			string pTransType,
			string pItem,
			string pLocation,
			string pLot,
			string pCurWhse,
			decimal? pQty,
			string pUm,
			string pReasonCode,
			string pDocumentNum);
	}
}

