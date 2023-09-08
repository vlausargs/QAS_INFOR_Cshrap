//PROJECT NAME: DataCollection
//CLASS NAME: IDcmoveTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmoveTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcmoveTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

