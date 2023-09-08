//PROJECT NAME: DataCollection
//CLASS NAME: IDcDcsfcP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcDcsfcP
	{
		(int? ReturnCode, int? StopPost,
		int? PCanOverride,
		string Infobar) DcDcsfcPSp(Guid? DcsfcRowpointer,
		DateTime? PPostDate,
		int? StopPost,
		int? PCanOverride,
		string Infobar);
	}
}

