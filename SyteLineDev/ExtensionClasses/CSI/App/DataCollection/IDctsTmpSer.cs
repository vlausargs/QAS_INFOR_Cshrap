//PROJECT NAME: DataCollection
//CLASS NAME: IDctsTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctsTmpSer
	{
		(int? ReturnCode,
			string Infobar) DctsTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

