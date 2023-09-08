//PROJECT NAME: DataCollection
//CLASS NAME: IDcmatlTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmatlTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcmatlTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

