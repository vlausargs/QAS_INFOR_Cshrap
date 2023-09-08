//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXSetShipCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXSetShipCustomer
	{
		(int? ReturnCode,
			int? oJurisCd,
			int? oGeo,
			string oState,
			string oCity,
			string oZip,
			string oCnty,
			string oCountry,
			string oAddr1,
			string oAddr2,
			string oAddr3,
			string oAddr4,
			string Infobar) SSSVTXSetShipCustomerSp(
			string iCustNum,
			int? iCustSeq,
			int? oJurisCd,
			int? oGeo,
			string oState,
			string oCity,
			string oZip,
			string oCnty,
			string oCountry,
			string oAddr1,
			string oAddr2,
			string oAddr3,
			string oAddr4,
			string Infobar);
	}
}

