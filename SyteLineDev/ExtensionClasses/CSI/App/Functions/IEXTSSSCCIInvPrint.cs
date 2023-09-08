//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIInvPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIInvPrint
	{
		(int? ReturnCode,
			decimal? TcAmtPrepaidAmt,
			string Item_1,
			string Infobar) EXTSSSCCIInvPrintSp(
			string InvNum,
			string InvCred,
			int? CurrencyPlaces,
			string CurrparmsCurrCode,
			decimal? TcAmtPrepaidAmt,
			string Item_1,
			string Infobar);
	}
}

