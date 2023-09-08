//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXValidateAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXValidateAddress
	{
		(int? ReturnCode, string ioGeo,
		string iState,
		string iCity,
		string iZip,
		string iCnty,
		string iCountry,
		string iAddr1,
		string iAddr2,
		string iAddr3,
		string iAddr4,
		int? oValid,
		string Infobar) SSSVTXValidateAddressSp(int? iUpdateRecord,
		string iCustNum,
		int? iCustSeq,
		string ioGeo,
		string iState,
		string iCity,
		string iZip,
		string iCnty,
		string iCountry,
		string iAddr1,
		string iAddr2,
		string iAddr3,
		string iAddr4,
		int? oValid,
		string iAddressType,
		string Infobar);
	}
}

