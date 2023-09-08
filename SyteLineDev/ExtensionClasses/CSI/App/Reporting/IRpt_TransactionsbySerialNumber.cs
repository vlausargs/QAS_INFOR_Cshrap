//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TransactionsbySerialNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TransactionsbySerialNumber
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransactionsbySerialNumberSp(string BegSerNum = null,
		string EndSerNum = null,
		string BegItem = null,
		string EndItem = null,
		string BegLot = null,
		string EndLot = null,
		int? DisplayHeader = null,
		string MessageLanguage = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

