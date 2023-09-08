//PROJECT NAME: DataCollection
//CLASS NAME: IDcjmP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjmP
	{
		(int? ReturnCode, string Infobar) DcjmPSp(int? PTransNum,
		string Infobar,
		string DocumentNum = null);
	}
}

