//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCreateCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCreateCo
	{
		(int? ReturnCode,
			string TCoNum,
			string Infobar) SSSPOSCreateCoSp(
			string POSNum,
			string POSMTermsCode,
			string CurUserCode,
			string ParmSite,
			string POSMCustNum,
			int? POSMCustSeq,
			decimal? POSMDisc,
			string POSMCustPo,
			Guid? POSMRowPointer,
			string POSMTaxCode1,
			string POSMTaxCode2,
			string POSMShipCode,
			decimal? POSMSalesTax,
			decimal? POSMSalesTax2,
			string POSMFrtTaxCode1,
			string POSMFrtTaxCode2,
			string POSMMscTaxCode1,
			string POSMMscTaxCode2,
			decimal? POSMFreight,
			decimal? POSMMiscCharges,
			string POSMContact,
			string POSMPhone,
			string POSMWhse,
			string POSMSlsman,
			string POSMEndUserType,
			string TCoNum,
			string Infobar);
	}
}

