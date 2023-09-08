//PROJECT NAME: DataCollection
//CLASS NAME: IDccoPostLoop.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccoPostLoop
	{
		(int? ReturnCode,
			string Infobar) DccoPostLoopSp(
			DateTime? PostDate,
			string Infobar);
	}
}

