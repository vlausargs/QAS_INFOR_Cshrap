//PROJECT NAME: Data
//CLASS NAME: ITaxId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaxId
	{
		(int? ReturnCode,
			string rTaxRegNum,
			string rCustRegNum,
			string Infobar,
			string CustShipToRegNum) TaxIdSp(
			int? pTaxSystem,
			string pTaxCode,
			int? pBranchDefined,
			string pCustAddrCountry = null,
			string Custnum = null,
			string rTaxRegNum = null,
			string rCustRegNum = null,
			string Infobar = null,
			int? CustSeq = 0,
			string CustShipToRegNum = null);
	}
}

