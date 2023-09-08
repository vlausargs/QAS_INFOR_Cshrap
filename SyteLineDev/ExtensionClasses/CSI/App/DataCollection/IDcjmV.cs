//PROJECT NAME: DataCollection
//CLASS NAME: IDcjmV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjmV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcjmVSp(
			int? DcjmTransNum,
			int? CanOverride,
			string Infobar);
	}
}

