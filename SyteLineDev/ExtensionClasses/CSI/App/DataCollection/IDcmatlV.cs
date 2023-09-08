//PROJECT NAME: DataCollection
//CLASS NAME: IDcmatlV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmatlV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcmatlVSp(
			int? DcitemTransNum,
			int? CanOverride,
			string Infobar);
	}
}

