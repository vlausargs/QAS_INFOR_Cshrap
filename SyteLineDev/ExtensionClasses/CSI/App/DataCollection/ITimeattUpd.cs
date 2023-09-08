//PROJECT NAME: DataCollection
//CLASS NAME: ITimeattUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface ITimeattUpd
	{
		int? TimeattUpdSp(string Shift,
		DateTime? PostDate,
		DateTime? PostTime,
		Guid? RowPointer);
	}
}

