//PROJECT NAME: Production
//CLASS NAME: IGenUnpostedJobTransForBatchedProd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGenUnpostedJobTransForBatchedProd
	{
		(int? ReturnCode, string Infobar) GenUnpostedJobTransForBatchedProdSp(int? ProdBatchId,
		string TransType,
		DateTime? TransDate,
		decimal? QtyComplete,
		decimal? QtyScrapped,
		decimal? AHrs,
		string EmpNum,
		int? StartTimeHrs,
		int? EndTimeHrs,
		string IndCode,
		string PayRate,
		decimal? QtyMoved,
		string UserCode,
		decimal? PrRate,
		decimal? JobRate,
		string Shift,
		string ReasonCode,
		string Loc,
		string ContainerNum,
		string Lot,
		string CostCode,
		string Infobar);
	}
}

