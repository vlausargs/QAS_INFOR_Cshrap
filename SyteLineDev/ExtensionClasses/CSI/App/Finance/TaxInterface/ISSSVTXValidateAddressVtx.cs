//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXValidateAddressVtx.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXValidateAddressVtx
	{
		(int? ReturnCode,
			string ioGeo,
			int? oValid,
			string Infobar) SSSVTXValidateAddressVtxSp(
			string ioGeo,
			string iState,
			string iCity,
			string iZip,
			string iCnty,
			string iCountry,
			int? oValid,
			string Infobar);
	}
}

