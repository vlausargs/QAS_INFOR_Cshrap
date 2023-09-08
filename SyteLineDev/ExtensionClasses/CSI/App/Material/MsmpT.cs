//PROJECT NAME: Material
//CLASS NAME: MsmpT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MsmpT : IMsmpT
	{
		readonly IApplicationDB appDB;
		
		public MsmpT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MsmpTSp(
			string PType,
			DateTime? PDate,
			decimal? PQty,
			string PItem,
			string PFromCurrCode,
			string PFromSite,
			string PToSite,
			string PToWhse,
			string PToLoc,
			string PToLot,
			string PTrnNum,
			int? PTrnLine,
			decimal? PTransNum,
			decimal? PRsvdNum,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			decimal? PMatlCost,
			decimal? PLbrCost,
			decimal? PVovhdCost,
			decimal? PFovhdCost,
			decimal? POutCost,
			decimal? PTotCost,
			decimal? PProfitMarkup,
			string Infobar,
			Guid? TmpSerId = null,
			int? UseExistingSerials = null,
			string SerialPrefix = null,
			string RemoteSiteLot = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string PImportDocId = null,
			string ReasonCode = null,
			string DocumentNum = null)
		{
			LongListType _PType = PType;
			DateType _PDate = PDate;
			QtyUnitType _PQty = PQty;
			ItemType _PItem = PItem;
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			SiteType _PFromSite = PFromSite;
			SiteType _PToSite = PToSite;
			WhseType _PToWhse = PToWhse;
			LocType _PToLoc = PToLoc;
			LotType _PToLot = PToLot;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			HugeTransNumType _PTransNum = PTransNum;
			RsvdNumType _PRsvdNum = PRsvdNum;
			EmpJobCoPoRmaProjPsTrnNumType _PRefNum = PRefNum;
			VariousSmallRefLineType _PRefLineSuf = PRefLineSuf;
			CoReleaseOperNumPoReleaseType _PRefRelease = PRefRelease;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _POutCost = POutCost;
			CostPrcType _PTotCost = PTotCost;
			CostPrcType _PProfitMarkup = PProfitMarkup;
			InfobarType _Infobar = Infobar;
			RowPointerType _TmpSerId = TmpSerId;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ListExistingCreateBothType _RemoteSiteLot = RemoteSiteLot;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			ImportDocIdType _PImportDocId = PImportDocId;
			ReasonCodeType _ReasonCode = ReasonCode;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MsmpTSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToWhse", _PToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToLoc", _PToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToLot", _PToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdNum", _PRsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProfitMarkup", _PProfitMarkup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLot", _RemoteSiteLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
