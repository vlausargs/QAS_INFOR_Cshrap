//PROJECT NAME: CSIProjects
//CLASS NAME: prjresValidateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IprjresValidateItem
	{
		(int? ReturnCode, string PItem, decimal? PCost, byte? PBackflush, string PRefType, string PMatlType, string PUnits, decimal? PMatlCost, decimal? PLbrCost, decimal? PFovhdCost, decimal? PVovhdCost, decimal? POutCost, decimal? PFmatlovhd, decimal? PVmatlovhd, string PUM, byte? PItemAvail, string PItemDesc, byte? PItemSerialTracked, string PCostCode, string Infobar, string Prompt, string PromptButtons, byte? SupplQtyReq, double? SupplQtyConvFactor, string Origin, string CommCode, decimal? UnitWeight, byte? Kit) prjresValidateItemSp(string PItem,
		string POldItem,
		string PProj,
		byte? PAddMode,
		decimal? PCost,
		byte? PBackflush,
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
		byte? PItemAvail,
		string PItemDesc,
		byte? PItemSerialTracked,
		string PCostCode,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null,
		byte? SupplQtyReq = (byte)0,
		double? SupplQtyConvFactor = 1,
		string Origin = null,
		string CommCode = null,
		decimal? UnitWeight = 0,
		byte? Kit = null);
	}
	
	public class prjresValidateItem : IprjresValidateItem
	{
		readonly IApplicationDB appDB;
		
		public prjresValidateItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PItem, decimal? PCost, byte? PBackflush, string PRefType, string PMatlType, string PUnits, decimal? PMatlCost, decimal? PLbrCost, decimal? PFovhdCost, decimal? PVovhdCost, decimal? POutCost, decimal? PFmatlovhd, decimal? PVmatlovhd, string PUM, byte? PItemAvail, string PItemDesc, byte? PItemSerialTracked, string PCostCode, string Infobar, string Prompt, string PromptButtons, byte? SupplQtyReq, double? SupplQtyConvFactor, string Origin, string CommCode, decimal? UnitWeight, byte? Kit) prjresValidateItemSp(string PItem,
		string POldItem,
		string PProj,
		byte? PAddMode,
		decimal? PCost,
		byte? PBackflush,
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
		byte? PItemAvail,
		string PItemDesc,
		byte? PItemSerialTracked,
		string PCostCode,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null,
		byte? SupplQtyReq = (byte)0,
		double? SupplQtyConvFactor = 1,
		string Origin = null,
		string CommCode = null,
		decimal? UnitWeight = 0,
		byte? Kit = null)
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
			FlagNyType _PItemAvail = PItemAvail;
			DescriptionType _PItemDesc = PItemDesc;
			ListYesNoType _PItemSerialTracked = PItemSerialTracked;
			CostCodeType _PCostCode = PCostCode;
			InfobarType _Infobar = Infobar;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			FlagNyType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			EcCodeType _Origin = Origin;
			CommodityCodeType _CommCode = CommCode;
			UnitWeightType _UnitWeight = UnitWeight;
			ListYesNoType _Kit = Kit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "prjresValidateItemSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.InputOutput);
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
				appDB.AddCommandParameter(cmd, "PItemAvail", _PItemAvail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemSerialTracked", _PItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCostCode", _PCostCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItem = _PItem;
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
				PItemAvail = _PItemAvail;
				PItemDesc = _PItemDesc;
				PItemSerialTracked = _PItemSerialTracked;
				PCostCode = _PCostCode;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				Origin = _Origin;
				CommCode = _CommCode;
				UnitWeight = _UnitWeight;
				Kit = _Kit;
				
				return (Severity, PItem, PCost, PBackflush, PRefType, PMatlType, PUnits, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PFmatlovhd, PVmatlovhd, PUM, PItemAvail, PItemDesc, PItemSerialTracked, PCostCode, Infobar, Prompt, PromptButtons, SupplQtyReq, SupplQtyConvFactor, Origin, CommCode, UnitWeight, Kit);
			}
		}
	}
}
