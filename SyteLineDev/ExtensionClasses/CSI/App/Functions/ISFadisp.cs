//PROJECT NAME: Data
//CLASS NAME: ISFadisp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISFadisp
	{
		(int? ReturnCode,
			string Infobar) SFadispSp(
			string FadispFaNum,
			decimal? FadispDisposeAmt,
			decimal? FadispGainLoss,
			string Infobar);
	}
}

