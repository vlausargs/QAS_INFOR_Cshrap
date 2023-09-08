//PROJECT NAME: Material
//CLASS NAME: IItemOrCustItemLov.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemOrCustItemLov
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ItemOrCustItemLovSp(int? CIFlag,
		string CustNum,
		string Item);
	}
}

