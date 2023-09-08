//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcTmpSer
	{
		(int? ReturnCode,
			string Infobar) DcsfcTmpSerSp(
			int? PTransNum,
			string Infobar);
	}
}

