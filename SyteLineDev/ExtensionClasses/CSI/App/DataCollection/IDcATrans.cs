//PROJECT NAME: DataCollection
//CLASS NAME: IDcATrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcATrans
	{
		(int? ReturnCode, string InfoBar) DcATransSp(string pTermId,
		string TTransType,
		string pEmpNum,
		DateTime? pTransDate,
		string pTransfer,
		int? pLine,
		string pUM,
		decimal? pQty,
		string pLoc,
		string pLot,
		string pTrnLot,
		string pRemoteSiteTrnLotProcess,
		int? pUseExistingSerials,
		string InfoBar);
	}
}

