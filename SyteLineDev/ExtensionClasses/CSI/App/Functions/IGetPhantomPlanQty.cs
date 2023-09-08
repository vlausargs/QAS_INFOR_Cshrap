//PROJECT NAME: Data
//CLASS NAME: IGetPhantomPlanQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPhantomPlanQty
	{
		decimal? GetPhantomPlanQtyFn(
			string PLN_Ref_Type,
			string PLN_Ref_Num,
			Guid? JobmatlRowPointer);
	}
}

