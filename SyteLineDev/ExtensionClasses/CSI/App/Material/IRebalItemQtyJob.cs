//PROJECT NAME: Material
//CLASS NAME: IRebalItemQtyJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRebalItemQtyJob
	{
		(int? ReturnCode, string Infobar) RebalItemQtyJobSp(string Infobar,
		string StartingItem = null,
		string EndingItem = null,
		string StartingWhse = null,
		string EndingWhse = null);
	}
}

