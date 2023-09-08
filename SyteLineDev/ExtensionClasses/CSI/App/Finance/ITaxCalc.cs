//PROJECT NAME: Finance
//CLASS NAME: ITaxCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITaxCalc
	{
		(int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) TaxCalcSp(
			string PInvType,
			string PTaxCode1,
			string PTaxCode2,
			decimal? PFreight,
			string PFrtTaxCode1,
			string PFrtTaxCode2,
			decimal? PMisc,
			string PMiscTaxCode1,
			string PMiscTaxCode2,
			DateTime? PInvDate,
			string PTermsCode,
			int? PUseExchRate,
			string PCurrCode,
			int? PPlaces,
			decimal? PExchRate,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar,
			string CalledFrom = null,
			Guid? tpsProcessId = null,
			string pRefType = null,
			Guid? pHdrPtr = null,
			int? LocalInit = 1,
			int? UseExtFin = null,
			int? UseExternalTaxCalc = null,
			int? EXTGEN_TaxCalcSp_Exists = null,
			int? IsTaxInterfaceAvailable = null,
			int? vrtx_parm_Exists = null,
			decimal? TaxFactor = null,
			int? CoShipmentApprovalRequired = 0,
			string Site = null,
			string DomCurrCode = null,
			int? IsJapanInterfaceAvailable = null);
	}
}

