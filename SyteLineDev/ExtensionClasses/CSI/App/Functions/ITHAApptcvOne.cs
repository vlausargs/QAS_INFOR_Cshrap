//PROJECT NAME: Data
//CLASS NAME: ITHAApptcvOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcvOne
	{
		(int? ReturnCode,
			string Infobar) THAApptcvOneSp(
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

