//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSSSSCCISROBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSSSSCCISROBal
	{
		(int? ReturnCode,
			decimal? Balance,
			decimal? TaxAmt,
			decimal? ExchRate,
			decimal? ForAmt,
			string Infobar) EXTSSSFSSSSCCISROBalSp(
			string SroNum,
			string AuthType,
			decimal? AuthAmount,
			decimal? Balance,
			decimal? TaxAmt,
			decimal? ExchRate,
			decimal? ForAmt,
			string Infobar);
	}
}

