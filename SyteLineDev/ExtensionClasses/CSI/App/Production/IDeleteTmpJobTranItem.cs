//PROJECT NAME: Production
//CLASS NAME: IDeleteTmpJobTranItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IDeleteTmpJobTranItem
	{
		int? DeleteTmpJobTranItemSp(Guid? TmpJobTranItemId);
	}
}

