//PROJECT NAME: Material
//CLASS NAME: IItemCopyData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemCopyData
	{
		(int? ReturnCode, string Infobar) ItemCopyDataSp(string FromItem,
		string NewItem,
		int? CopyUDF,
		int? CopyLoc,
		int? CopyBOM,
		string CopyBOMType,
		DateTime? EffectDate,
		int? PlanFlag,
		string FeatStr,
		string Process = "C",
		string Infobar = null,
		int? CopyUetValues = 0);
	}
}

