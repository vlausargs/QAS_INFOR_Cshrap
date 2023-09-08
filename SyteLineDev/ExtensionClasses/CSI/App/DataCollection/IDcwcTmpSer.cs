//PROJECT NAME: DataCollection
//CLASS NAME: IDcwcTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcwcTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcwcTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

