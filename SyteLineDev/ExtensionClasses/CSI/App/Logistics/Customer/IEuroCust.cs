//PROJECT NAME: Logistics
//CLASS NAME: IEuroCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEuroCust
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string rInfobar) EuroCustSp(string pProcess,
		string pBeginCustNum1,
		string pEndCustNum1,
		string pBeginCustNum2 = null,
		string pEndCustNum2 = null,
		string pBeginCustNum3 = null,
		string pEndCustNum3 = null,
		string pBeginCustNum4 = null,
		string pEndCustNum4 = null,
		string pBeginCustNum5 = null,
		string pEndCustNum5 = null,
		string pBeginCustNum6 = null,
		string pEndCustNum6 = null,
		string pBeginCustNum7 = null,
		string pEndCustNum7 = null,
		string pBeginCustNum8 = null,
		string pEndCustNum8 = null,
		string pBeginCustNum9 = null,
		string pEndCustNum9 = null,
		string pBeginCustNum10 = null,
		string pEndCustNum10 = null,
		string pInCurrencyCode = null,
		string rInfobar = null);
	}
}

