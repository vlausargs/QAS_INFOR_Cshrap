//PROJECT NAME: Finance
//CLASS NAME: IApPmtvOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApPmtvOne
	{
		(int? ReturnCode,
			string Infobar) ApPmtvOneSp(
			string AppmtVendNum,
			DateTime? AppmtCheckDate,
			int? AppmtCheckSeq,
			string AppmtPayType,
			int? AppmtCheckNum,
			string AppmtBankCode,
			decimal? AppmtDomCheckAmt,
			string AppmtRef,
			decimal? AppmtForCheckAmt,
			string Infobar);
	}
}

