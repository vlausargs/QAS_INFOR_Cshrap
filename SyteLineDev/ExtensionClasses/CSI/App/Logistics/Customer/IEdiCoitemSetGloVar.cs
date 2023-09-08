//PROJECT NAME: Logistics
//CLASS NAME: IEdiCoitemSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEdiCoitemSetGloVar
	{
		int? EdiCoitemSetGloVarSp(int? ItemCustAdd = 0,
		int? ItemCustUpdate = 0,
		int? AllowOverCreditLimit = 0);
	}
}

