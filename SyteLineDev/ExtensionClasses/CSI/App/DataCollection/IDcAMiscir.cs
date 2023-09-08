//PROJECT NAME: DataCollection
//CLASS NAME: IDcAMiscir.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAMiscir
	{
		(int? ReturnCode, string Infobar) DcAMiscirSp(string TTermId,
		string pTransType,
		string pEmpNum,
		DateTime? TTransDate,
		string pItem,
		string pCurWhse,
		string pLocation,
		string pLot,
		decimal? pQty,
		string pUm,
		string pReasonCode,
		string pDocumentNum,
		string Infobar);
	}
}

