//PROJECT NAME: DataCollection
//CLASS NAME: IDcpoP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpoP
	{
		(int? ReturnCode, string Infobar) DcpoPSp(int? PTransNum,
		string Infobar,
		string DocumentNum = null);
	}
}

