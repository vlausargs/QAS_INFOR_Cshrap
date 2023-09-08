//PROJECT NAME: Data
//CLASS NAME: IIsItemBOMExisted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsItemBOMExisted
	{
		int? IsItemBOMExistedFn(
			string Item);
	}
}

