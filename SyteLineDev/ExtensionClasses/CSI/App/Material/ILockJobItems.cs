//PROJECT NAME: Material
//CLASS NAME: ILockJobItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ILockJobItems
	{
		int? LockJobItemsSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? QtyMoved,
		int? Lock = 1);
	}
}

