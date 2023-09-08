//PROJECT NAME: Data
//CLASS NAME: IDeleteCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteCo
	{
		int? DeleteCoSp(
			string CoNum,
			int? RepFromTrigger = 0,
			string RepFromSite = null);
	}
}

