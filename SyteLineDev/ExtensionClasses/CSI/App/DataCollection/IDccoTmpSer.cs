//PROJECT NAME: DataCollection
//CLASS NAME: IDccoTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccoTmpSer
	{
		(int? ReturnCode,
			string Infobar) DccoTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

