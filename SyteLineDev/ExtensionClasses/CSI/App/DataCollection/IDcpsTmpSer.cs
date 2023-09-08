//PROJECT NAME: DataCollection
//CLASS NAME: IDcpsTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpsTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcpsTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

