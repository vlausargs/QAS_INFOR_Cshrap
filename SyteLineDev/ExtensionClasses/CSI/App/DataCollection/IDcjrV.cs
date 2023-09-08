//PROJECT NAME: DataCollection
//CLASS NAME: IDcjrV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjrV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcjrVSp(
			int? DcjmTransNum,
			int? CanOverride,
			string Infobar);
	}
}

