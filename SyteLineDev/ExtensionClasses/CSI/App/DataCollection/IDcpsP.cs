//PROJECT NAME: DataCollection
//CLASS NAME: IDcpsP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpsP
	{
		(int? ReturnCode, string Infobar) DcpsPSp(string PDcpsType,
		int? PTransNum,
		string Infobar,
		string DocumentNum = null);
	}
}

