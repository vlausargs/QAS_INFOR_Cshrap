//PROJECT NAME: Material
//CLASS NAME: MvPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MvPost : IMvPost
	{
		readonly IApplicationDB appDB;
		
		
		public MvPost(IApplicationDB appDB)
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
		string Infobar) MvPostSp(string PType,
		DateTime? PDate,
		decimal? PQty,
		string PItem,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToWhse,
		string ToLoc,
		string ToLot,
		int? PZeroCost,
		string PTrnNum,
		int? PTrnLine,
		decimal? PTransNum,
		decimal? PRsvdNum,
		string PStat,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string RefStr = null,
		decimal? PUnitCost = null,
		decimal? PMatlCost = null,
		decimal? PLbrCost = null,
		decimal? PFovhdCost = null,
		decimal? PVovhdCost = null,
		decimal? POutCost = null,
		decimal? PTotCost = null,
		string Infobar = null,
		string DocumentNum = null,
		string FromImportDocId = null,
		string ToImportDocId = null,
		string ReasonCode = null,
		string EmpNum = null,
		DateTime? FromSiteRecordDate = null)
		{
			DefaultCharType _PType = PType;
			DateType _PDate = PDate;
			QtyUnitType _PQty = PQty;
			ItemType _PItem = PItem;
			WhseType _FromWhse = FromWhse;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			WhseType _ToWhse = ToWhse;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			ListYesNoType _PZeroCost = PZeroCost;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			HugeTransNumType _PTransNum = PTransNum;
			RsvdNumType _PRsvdNum = PRsvdNum;
			SerialStatusType _PStat = PStat;
			EmpJobCoPoRmaProjPsTrnNumType _PRefNum = PRefNum;
			VariousSmallRefLineType _PRefLineSuf = PRefLineSuf;
			CoReleaseOperNumPoReleaseType _PRefRelease = PRefRelease;
			RefStrType _RefStr = RefStr;
			CostPrcType _PUnitCost = PUnitCost;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			CostPrcType _PTotCost = PTotCost;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			ImportDocIdType _FromImportDocId = FromImportDocId;
			ImportDocIdType _ToImportDocId = ToImportDocId;
			ReasonCodeType _ReasonCode = ReasonCode;
			EmpNumType _EmpNum = EmpNum;
			CurrentDateType _FromSiteRecordDate = FromSiteRecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MvPostSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PZeroCost", _PZeroCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdNum", _PRsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCost", _PUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromImportDocId", _FromImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToImportDocId", _ToImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSiteRecordDate", _FromSiteRecordDate, ParameterDirection.Input);
				
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
