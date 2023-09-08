//PROJECT NAME: DataCollection
//CLASS NAME: IDcjrP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjrP
	{
		(int? ReturnCode, int? pCanOverride,
		string Infobar) DcjrPSp(int? PTransNum,
		int? pCanOverride,
		string Infobar);
	}
}

