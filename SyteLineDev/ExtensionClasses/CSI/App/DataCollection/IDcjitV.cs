//PROJECT NAME: DataCollection
//CLASS NAME: IDcjitV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjitV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcjitVSp(
			int? DcjitTransNum,
			int? CanOverride,
			string Infobar);
	}
}

