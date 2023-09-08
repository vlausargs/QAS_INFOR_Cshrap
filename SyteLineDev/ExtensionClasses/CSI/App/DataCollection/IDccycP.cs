//PROJECT NAME: DataCollection
//CLASS NAME: IDccycP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccycP
	{
		(int? ReturnCode, string Infobar) DccycPSp(int? PTransNum,
		string Infobar);
	}
}

