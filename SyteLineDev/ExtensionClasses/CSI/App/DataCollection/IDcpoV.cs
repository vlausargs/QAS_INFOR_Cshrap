//PROJECT NAME: DataCollection
//CLASS NAME: IDcpoV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpoV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcpoVSp(
			int? DcpoTransNum,
			int? CanOverride,
			string Infobar);
	}
}

