//PROJECT NAME: DataCollection
//CLASS NAME: IDcmoveP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmoveP
	{
		(int? ReturnCode, int? PCanOverride,
		string Infobar) DcmovePSp(int? PTransNum,
		int? PCanOverride,
		string Infobar);
	}
}

