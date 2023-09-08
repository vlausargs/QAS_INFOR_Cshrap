//PROJECT NAME: Data
//CLASS NAME: IFRTaxId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFRTaxId
	{
		(int? ReturnCode,
			string rTaxRegNum,
			string rCustRegNum,
			string rVendRegNum,
			string Infobar,
			string CustShipToRegNum) FRTaxIdSp(
			int? pTaxSystem,
			string pTaxCode,
			int? pBranchDefined,
			string pCustAddrCountry = null,
			string Custnum = null,
			string rTaxRegNum = null,
			string rCustRegNum = null,
			string rVendRegNum = null,
			string Infobar = null,
			int? CustSeq = 0,
			string CustShipToRegNum = null);
	}
}

