//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroPlanTransPostMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroPlanTransPostMatl
	{
		(int? ReturnCode, string Infobar) SSSFSSroPlanTransPostMatlSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstMatlQtyConv,
		decimal? iMatlCostConv,
		decimal? iLbrCostConv,
		decimal? iFovhdCostConv,
		decimal? iVovhdCostConv,
		decimal? iOutCostConv,
		string UpdateStatus,
		string Infobar);
	}
}

