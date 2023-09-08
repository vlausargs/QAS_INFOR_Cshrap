//PROJECT NAME: Data
//CLASS NAME: IPrtrxf1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtrxf1
	{
		(int? ReturnCode,
			decimal? PrtrxGrossPay,
			decimal? PrtrxRegPay,
			decimal? PrtrxOtPay,
			decimal? PrtrxDtPay,
			decimal? PrtrxHolPay,
			decimal? PrtrxSickPay,
			decimal? PrtrxVacPay,
			decimal? PrtrxOthPay,
			decimal? PrtrxSupplEarn,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxCoPdInsG,
			decimal? PrtrxCoPdIns,
			decimal? PrtrxEmprConG,
			decimal? PrtrxEmprCon,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar) Prtrxf1Sp(
			string PrtrxEmpNum,
			decimal? PrtrxGrossPay,
			decimal? PrtrxRegPay,
			decimal? PrtrxOtPay,
			decimal? PrtrxDtPay,
			decimal? PrtrxHolPay,
			decimal? PrtrxSickPay,
			decimal? PrtrxVacPay,
			decimal? PrtrxOthPay,
			decimal? PrtrxSupplEarn,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxCoPdInsG,
			decimal? PrtrxCoPdIns,
			decimal? PrtrxEmprConG,
			decimal? PrtrxEmprCon,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar);
	}
}

