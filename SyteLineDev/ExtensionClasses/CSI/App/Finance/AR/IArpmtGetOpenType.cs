//PROJECT NAME: Finance
//CLASS NAME: IArpmtGetOpenType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtGetOpenType
	{
		(int? ReturnCode,
			string POpenType,
			string POpenCode,
			decimal? PForCheckAmt,
			decimal? PExchRate,
			string PBankCode,
			string Infobar,
			string POpenCurrCode) ArpmtGetOpenTypeSp(
			string PCustNum,
			int? PCheckNum,
			string POpenType,
			string POpenCode,
			decimal? PForCheckAmt,
			decimal? PExchRate,
			string PBankCode,
			string Infobar,
			string PCreditMemoNum = null,
			string POpenCurrCode = null);

		string ArpmtGetOpenTypeFn(
			string PCustNum,
			int? PCheckNum);
	}
}

