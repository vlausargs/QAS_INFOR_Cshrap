//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetContractExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetContractExchRate
	{
		(int? ReturnCode,
			decimal? PExchRate,
			decimal? Result,
			string Infobar) SSSFSGetContractExchRateSp(
			string InContractNum,
			string PCustCurrCode,
			int? PTransDom,
			int? PUseBuyRate,
			int? PUseRoundFactor,
			DateTime? PDate,
			decimal? PExchRate,
			decimal? Amount,
			decimal? Result,
			string Infobar);
	}
}

