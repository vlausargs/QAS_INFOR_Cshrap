//PROJECT NAME: DataCollection
//CLASS NAME: IDcwcV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcwcV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcwcVSp(
			int? DcwcTransNum,
			int? CanOverride,
			string Infobar);
	}
}

