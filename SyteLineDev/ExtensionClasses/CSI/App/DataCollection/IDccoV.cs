//PROJECT NAME: DataCollection
//CLASS NAME: IDccoV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccoV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DccoVSp(
			int? DccoTransNum,
			int? CanOverride,
			string Infobar);
	}
}

