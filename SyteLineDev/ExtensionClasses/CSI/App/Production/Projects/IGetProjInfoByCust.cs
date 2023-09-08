//PROJECT NAME: Production
//CLASS NAME: IGetProjInfoByCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IGetProjInfoByCust
	{
		(int? ReturnCode, string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		string CurrCode,
		int? Fixed,
		string InvTermsCode,
		string BillToAddress,
		string ShipToAddress,
		int? CreditHold,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string Infobar,
		string ShipToCountry,
		string EndUserType,
		string EndUserTypeDesc) GetProjInfoByCustSp(string CustNum,
		int? CustSeq,
		string ProjType,
		int? TaxSyst1Enable,
		string TaxMode1,
		int? TaxSyst2Enable,
		string TaxMode2,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		string CurrCode,
		int? Fixed,
		string InvTermsCode,
		string BillToAddress,
		string ShipToAddress,
		int? CreditHold,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string Infobar,
		string ShipToCountry,
		string EndUserType,
		string EndUserTypeDesc);
	}
}

