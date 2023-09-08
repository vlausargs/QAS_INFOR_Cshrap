//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroPlanTransPostLabor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroPlanTransPostLabor
	{
		(int? ReturnCode, string Infobar) SSSFSSroPlanTransPostLaborSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstHrsWorked,
		decimal? iPstHrsToBill,
		decimal? iMatlCost,
		decimal? iLbrCost,
		decimal? iFovhdCost,
		decimal? iVovhdCost,
		decimal? iOutCost,
		string UpdateStatus,
		string Infobar);
	}
}

