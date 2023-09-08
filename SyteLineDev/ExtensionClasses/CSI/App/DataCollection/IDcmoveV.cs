//PROJECT NAME: DataCollection
//CLASS NAME: IDcmoveV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmoveV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcmoveVSp(
			int? DcmoveTransNum,
			int? CanOverride,
			string Infobar);
	}
}

