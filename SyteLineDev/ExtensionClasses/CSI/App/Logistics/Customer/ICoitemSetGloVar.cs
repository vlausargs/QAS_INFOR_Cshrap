//PROJECT NAME: Logistics
//CLASS NAME: ICoitemSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemSetGloVar
	{
		int? CoitemSetGloVarSp(int? ItemCustAdd = 0,
		int? ItemCustUpdate = 0,
		int? AllowOverCreditLimit = 0);
	}
}

