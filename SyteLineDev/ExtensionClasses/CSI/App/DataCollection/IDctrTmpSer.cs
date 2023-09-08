//PROJECT NAME: DataCollection
//CLASS NAME: IDctrTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctrTmpSer
	{
		(int? ReturnCode,
			string Infobar) DctrTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

