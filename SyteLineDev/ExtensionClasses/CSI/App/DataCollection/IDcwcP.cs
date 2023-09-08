//PROJECT NAME: DataCollection
//CLASS NAME: IDcwcP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcwcP
	{
		(int? ReturnCode, string Infobar) DcwcPSp(int? PTransNum,
		string Infobar,
		string DocumentNum = null);
	}
}

