//PROJECT NAME: Production
//CLASS NAME: IRSQC_CCRGetPar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CCRGetPar
	{
		(int? ReturnCode, int? CustomerReviewDays,
		int? CustomerFollowupDays,
		int? EmailEnabled,
		int? ValidateCustomer,
		int? ValidateEmployee,
		int? ValidateItem) RSQC_CCRGetParms(int? CustomerReviewDays,
		int? CustomerFollowupDays,
		int? EmailEnabled,
		int? ValidateCustomer,
		int? ValidateEmployee,
		int? ValidateItem);
	}
}

