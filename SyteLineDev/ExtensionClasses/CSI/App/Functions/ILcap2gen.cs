//PROJECT NAME: Data
//CLASS NAME: ILcap2gen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILcap2gen
	{
		(int? ReturnCode,
			int? TDistSeq,
			string Infobar) Lcap2genSp(
			int? PSign,
			Guid? AptrxRowPointer,
			string TVendNum,
			decimal? TAmtDuty,
			decimal? TAmtFreight,
			decimal? TAmtBrokerage,
			decimal? TAmtLocFreight,
			decimal? TAmtInsurance,
			int? TDistSeq,
			string Infobar);
	}
}

