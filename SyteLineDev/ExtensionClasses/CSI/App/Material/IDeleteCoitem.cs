//PROJECT NAME: Material
//CLASS NAME: IDeleteCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IDeleteCoitem
	{
		int? DeleteCoitemSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? RepFromTrigger);
	}
}

