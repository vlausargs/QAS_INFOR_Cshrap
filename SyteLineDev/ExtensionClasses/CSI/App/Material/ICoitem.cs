//PROJECT NAME: Material
//CLASS NAME: ICoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICoitem
	{
		int? CoitemSp(string PMode,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string FromParmsSite);
	}
}

