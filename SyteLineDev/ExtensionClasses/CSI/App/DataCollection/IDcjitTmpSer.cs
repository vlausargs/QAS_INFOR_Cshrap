//PROJECT NAME: DataCollection
//CLASS NAME: IDcjitTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjitTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcjitTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

