//PROJECT NAME: Material
//CLASS NAME: IMrpExplodePhantom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpExplodePhantom
	{
		(int? ReturnCode,
			string Infobar) MrpExplodePhantomSp(
			string PhItem,
			decimal? PhGrossQty,
			DateTime? PhDueDate,
			string PhOrderType,
			string PhRefNum,
			int? PhRefSuf,
			string PhParent,
			string PhJob,
			int? PhSuffix,
			decimal? PhOrigQty,
			DateTime? TEffCutoff,
			int? MrpParmScrapFlag,
			Guid? ProcessId,
			string UserMrpPlanningType,
			string Infobar);
	}
}

