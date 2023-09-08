//PROJECT NAME: DataCollection
//CLASS NAME: IDcpoTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpoTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcpoTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

