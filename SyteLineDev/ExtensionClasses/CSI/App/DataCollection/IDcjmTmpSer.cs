//PROJECT NAME: DataCollection
//CLASS NAME: IDcjmTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjmTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcjmTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

