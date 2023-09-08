//PROJECT NAME: Data
//CLASS NAME: IPrtrxf2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtrxf2
	{
		(int? ReturnCode,
			decimal? PrtrxGrossPay,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar) Prtrxf2Sp(
			Guid? PrdecdRec,
			int? Index,
			string PrtrxEmpNum,
			decimal? PrtrxDeAmt__1,
			decimal? PrtrxDeAmt__2,
			decimal? PrtrxDeAmt__3,
			decimal? PrtrxDeAmt__4,
			decimal? PrtrxDeAmt__5,
			decimal? PrtrxDeAmt__6,
			decimal? PrtrxDeAmt__7,
			decimal? PrtrxDeAmt__8,
			decimal? PrtrxDeAmt__9,
			decimal? PrtrxDeAmt__10,
			decimal? PrtrxDeAmt__11,
			decimal? PrtrxDeAmt__12,
			decimal? PrtrxDeAmt__13,
			decimal? PrtrxDeAmt__14,
			decimal? PrtrxDeAmt__15,
			decimal? PrtrxDeAmt__16,
			decimal? PrtrxDeAmt__17,
			decimal? PrtrxDeAmt__18,
			decimal? PrtrxGrossPay,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar);
	}
}

