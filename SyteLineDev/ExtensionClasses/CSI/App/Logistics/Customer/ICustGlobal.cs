//PROJECT NAME: Logistics
//CLASS NAME: ICustGlobal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustGlobal
	{
		(int? ReturnCode,
		int? rGlobal) CustGlobalSp(
			string pCustNum,
			int? rGlobal);

		int? CustGlobalFn(
			string pCustNum);
	}
}

