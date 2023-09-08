//PROJECT NAME: Data
//CLASS NAME: prjresGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class prjresGetItemInfo : IprjresGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		public prjresGetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			ItemType _PItem = PItem;
			ItemType _POldItem = POldItem;
			ProjNumType _PProj = PProj;
			FlagNyType _PAddMode = PAddMode;
			CostPrcType _PCost = PCost;
			ListYesNoType _PBackflush = PBackflush;
			RefTypeIJPRType _PRefType = PRefType;
			MatlTypeType _PMatlType = PMatlType;
			JobmatlUnitsType _PUnits = PUnits;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			OverheadRateType _PFmatlovhd = PFmatlovhd;
			OverheadRateType _PVmatlovhd = PVmatlovhd;
			UMType _PUM = PUM;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "prjresGetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldItem", _POldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProj", _PProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddMode", _PAddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCost", _PCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBackflush", _PBackflush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlType", _PMatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnits", _PUnits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFmatlovhd", _PFmatlovhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVmatlovhd", _PVmatlovhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCost = _PCost;
				PBackflush = _PBackflush;
				PRefType = _PRefType;
				PMatlType = _PMatlType;
				PUnits = _PUnits;
				PMatlCost = _PMatlCost;
				PLbrCost = _PLbrCost;
				PFovhdCost = _PFovhdCost;
				PVovhdCost = _PVovhdCost;
				POutCost = _POutCost;
				PFmatlovhd = _PFmatlovhd;
				PVmatlovhd = _PVmatlovhd;
				PUM = _PUM;
				Infobar = _Infobar;
				
				return (Severity, PCost, PBackflush, PRefType, PMatlType, PUnits, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PFmatlovhd, PVmatlovhd, PUM, Infobar);
			}
		}
	}
}
