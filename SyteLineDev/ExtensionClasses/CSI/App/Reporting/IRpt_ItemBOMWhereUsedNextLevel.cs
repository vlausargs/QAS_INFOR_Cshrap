//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemBOMWhereUsedNextLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemBOMWhereUsedNextLevel
	{
		int? Rpt_ItemBOMWhereUsedNextLevelSp(
			int? Level,
			string TJobType,
			string History,
			string Item,
			string Orig_Item,
			DateTime? EffectiveDate,
			int? IndentedLevelView,
			int? TErr);
	}
}

