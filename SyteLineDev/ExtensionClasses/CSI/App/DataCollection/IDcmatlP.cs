//PROJECT NAME: DataCollection
//CLASS NAME: IDcmatlP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmatlP
	{
		(int? ReturnCode, int? PCanOverride,
		string Infobar) DcmatlPSp(int? PTransNum,
		int? PCanOverride,
		string Infobar);
	}
}

