//PROJECT NAME: Logistics
//CLASS NAME: IEstSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstSetGloVar
	{
		int? EstSetGloVarSp(int? EstSetLineStat);
	}
}

