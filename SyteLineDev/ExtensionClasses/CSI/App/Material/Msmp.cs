//PROJECT NAME: Material
//CLASS NAME: Msmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Msmp : IMsmp
	{
		readonly IApplicationDB appDB;
		
		
		public Msmp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string Infobar) MsmpSp(string PType,
		DateTime? PDate,
		decimal? PQty,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PFromLoc,
		string PFromLot,
		string PToSite,
		string PToWhse,
		string PToLoc,
		string PToLot,
		int? PZeroCost,
		string PTrnNum,
		int? PTrnLine,
		decimal? PTransNum,
		decimal? PRsvdNum,
		string PStat,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string RemoteSiteLot = null,
		string PReasonCode = null,
		decimal? PUnitCost = null,
		decimal? PMatlCost = null,
		decimal? PLbrCost = null,
		decimal? PFovhdCost = null,
		decimal? PVovhdCost = null,
		decimal? POutCost = null,
		decimal? PTotCost = null,
		string Infobar = null,
		string PImportDocId = null,
		int? MoveZeroCostItem = 0,
		string EmpNum = null,
		int? CheckExternalWhseFlag = 0,
		string DocumentNum = null)
		{
			LongListType _PType = PType;
			DateType _PDate = PDate;
			QtyUnitType _PQty = PQty;
			ItemType _PItem = PItem;
			SiteType _PFromSite = PFromSite;
			WhseType _PFromWhse = PFromWhse;
			LocType _PFromLoc = PFromLoc;
			LotType _PFromLot = PFromLot;
			SiteType _PToSite = PToSite;
			WhseType _PToWhse = PToWhse;
			LocType _PToLoc = PToLoc;
			LotType _PToLot = PToLot;
			FlagNyType _PZeroCost = PZeroCost;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			HugeTransNumType _PTransNum = PTransNum;
			RsvdNumType _PRsvdNum = PRsvdNum;
			SerialStatusType _PStat = PStat;
			EmpJobCoPoRmaProjPsTrnNumType _PRefNum = PRefNum;
			VariousSmallRefLineType _PRefLineSuf = PRefLineSuf;
			CoReleaseOperNumPoReleaseType _PRefRelease = PRefRelease;
			ListExistingCreateBothType _RemoteSiteLot = RemoteSiteLot;
			ReasonCodeType _PReasonCode = PReasonCode;
			CostPrcType _PUnitCost = PUnitCost;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			CostPrcType _PTotCost = PTotCost;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ListYesNoType _MoveZeroCostItem = MoveZeroCostItem;
			EmpNumType _EmpNum = EmpNum;
			IntType _CheckExternalWhseFlag = CheckExternalWhseFlag;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MsmpSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromWhse", _PFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromLoc", _PFromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromLot", _PFromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToWhse", _PToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToLoc", _PToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToLot", _PToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PZeroCost", _PZeroCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdNum", _PRsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLot", _RemoteSiteLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCost", _PUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveZeroCostItem", _MoveZeroCostItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckExternalWhseFlag", _CheckExternalWhseFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitCost = _PUnitCost;
				PMatlCost = _PMatlCost;
				PLbrCost = _PLbrCost;
				PFovhdCost = _PFovhdCost;
				PVovhdCost = _PVovhdCost;
				POutCost = _POutCost;
				PTotCost = _PTotCost;
				Infobar = _Infobar;
				
				return (Severity, PUnitCost, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, Infobar);
			}
		}
	}
}
