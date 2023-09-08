//PROJECT NAME: Codes
//CLASS NAME: IGetCustVendNumfromAcctRouting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetCustVendNumfromAcctRouting
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) GetCustVendNumfromAcctRoutingSp(string Account,
		string RoutingNumber,
		string InfoBar);

		ICollectionLoadResponse GetCustVendNumfromAcctRoutingFn(string BankAccount);
	}
}

