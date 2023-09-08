//PROJECT NAME: DataCollection
//CLASS NAME: IDcjrTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjrTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcjrTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

