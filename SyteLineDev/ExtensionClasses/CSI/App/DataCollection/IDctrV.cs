//PROJECT NAME: DataCollection
//CLASS NAME: IDctrV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctrV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DctrVSp(
			int? DctrTransNum,
			int? CanOverride,
			string Infobar);
	}
}

