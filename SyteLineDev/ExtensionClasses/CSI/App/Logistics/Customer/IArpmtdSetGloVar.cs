//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdSetGloVar
	{
		int? ArpmtdSetGloVarSp(int? TransferCash);
	}
}

