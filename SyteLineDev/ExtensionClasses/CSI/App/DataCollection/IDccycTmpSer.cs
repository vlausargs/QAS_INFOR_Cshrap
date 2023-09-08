//PROJECT NAME: DataCollection
//CLASS NAME: IDccycTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccycTmpSer
	{
		(int? ReturnCode,
			string Infobar) DccycTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

