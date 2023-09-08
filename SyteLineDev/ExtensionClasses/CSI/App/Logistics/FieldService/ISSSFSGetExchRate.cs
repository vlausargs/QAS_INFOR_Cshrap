//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetExchRate
	{
		(int? ReturnCode,
			decimal? PExchRate,
			decimal? Result,
			string Infobar) SSSFSGetExchRateSp(
			string InSRONum,
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

