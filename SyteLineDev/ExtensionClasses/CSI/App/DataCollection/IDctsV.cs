//PROJECT NAME: DataCollection
//CLASS NAME: IDctsV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctsV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DctsVSp(
			int? DctsTransNum,
			int? CanOverride,
			string Infobar);
	}
}

