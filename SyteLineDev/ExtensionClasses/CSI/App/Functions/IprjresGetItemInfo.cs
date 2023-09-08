//PROJECT NAME: Data
//CLASS NAME: IprjresGetItemInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IprjresGetItemInfo
	{
		(int? ReturnCode,
			decimal? PCost,
			int? PBackflush,
			string PRefType,
			string PMatlType,
			string PUnits,
			decimal? PMatlCost,
			decimal? PLbrCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			decimal? PFmatlovhd,
			decimal? PVmatlovhd,
			string PUM,
			string Infobar) prjresGetItemInfoSp(
			string PItem,
			string POldItem,
			string PProj,
			int? PAddMode,
			decimal? PCost,
			int? PBackflush,
			string PRefType,
			string PMatlType,
			string PUnits,
			decimal? PMatlCost,
			decimal? PLbrCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			decimal? PFmatlovhd,
			decimal? PVmatlovhd,
			string PUM,
			string Infobar);
	}
}

