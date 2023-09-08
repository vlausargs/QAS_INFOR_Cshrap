//PROJECT NAME: DataCollection
//CLASS NAME: IDctsP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctsP
	{
		(int? ReturnCode, string Infobar) DctsPSp(int? PTransNum,
		string Infobar,
		string DocumentNum = null);
	}
}

