//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroMiscRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroMiscRate
	{
		(int? ReturnCode, decimal? oUnitPrice,
		string Infobar) SSSFSSroMiscRateSp(string iTransType,
		string iSroNum,
		int? iSroLine,
		int? iSroOper,
		string iBillCode,
		DateTime? iTransDate,
		string iPartner,
		string iMiscCode,
		decimal? iUnitCost,
		decimal? iQty,
		decimal? oUnitPrice,
		string Infobar);
	}
}

