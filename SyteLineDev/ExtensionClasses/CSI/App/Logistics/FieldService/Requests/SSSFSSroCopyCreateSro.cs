//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyCreateSro.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCopyCreateSro
	{
		(int? ReturnCode, string oSRONum,
		int? oSROLine,
		int? oSROOper,
		string Infobar) SSSFSSroCopyCreateSroSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iSroCopyFromKey,
		string iTemplateSroNum,
		int? iTemplateSROLine,
		string iSelectedOpers,
		string iCustNum,
		int? iCustSeq,
		DateTime? iDate,
		string iBillMgr,
		string iSRODesc,
		string iSerNum,
		string iWhse,
		string iItemNum,
		string iUM,
		decimal? iQty,
		string iLineDesc,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		string oSRONum,
		int? oSROLine,
		int? oSROOper,
		string Infobar,
		byte? iKeepOperNums = (byte)0,
		string iFromRefType = null,
		string iFromRefNum = null,
		int? iFromRefLine = null,
		int? iFromRefRelease = null,
		byte? iUseSroWhse = (byte)0,
		string iSRONum = null,
		int? iConfigCompId = null,
		string iSroStat = "O",
		string iRegion = null,
		byte? iChkShowAllOpers = (byte)0,
		byte? iKeepLineNums = (byte)0,
		byte? iUseAllOpers = (byte)0,
		string iToSite = null,
		int? iSeq = 0,
		string iCustPo = null,
		DateTime? iStartDate = null,
		decimal? iDuration = null,
		string iCustItem = null,
		DateTime? iMaintDate = null,
		decimal? iDownTime = null,
		string iShiftID = null,
		byte? iSchedDownTime = null,
		byte? iCreateIncident = (byte)0,
		byte? iCopyLineTrans = (byte)0,
		string iUsrNum = null,
		int? iUsrSeq = null);
	}
	
	public class SSSFSSroCopyCreateSro : ISSSFSSroCopyCreateSro
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyCreateSro(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string oSRONum,
		int? oSROLine,
		int? oSROOper,
		string Infobar) SSSFSSroCopyCreateSroSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iSroCopyFromKey,
		string iTemplateSroNum,
		int? iTemplateSROLine,
		string iSelectedOpers,
		string iCustNum,
		int? iCustSeq,
		DateTime? iDate,
		string iBillMgr,
		string iSRODesc,
		string iSerNum,
		string iWhse,
		string iItemNum,
		string iUM,
		decimal? iQty,
		string iLineDesc,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		string oSRONum,
		int? oSROLine,
		int? oSROOper,
		string Infobar,
		byte? iKeepOperNums = (byte)0,
		string iFromRefType = null,
		string iFromRefNum = null,
		int? iFromRefLine = null,
		int? iFromRefRelease = null,
		byte? iUseSroWhse = (byte)0,
		string iSRONum = null,
		int? iConfigCompId = null,
		string iSroStat = "O",
		string iRegion = null,
		byte? iChkShowAllOpers = (byte)0,
		byte? iKeepLineNums = (byte)0,
		byte? iUseAllOpers = (byte)0,
		string iToSite = null,
		int? iSeq = 0,
		string iCustPo = null,
		DateTime? iStartDate = null,
		decimal? iDuration = null,
		string iCustItem = null,
		DateTime? iMaintDate = null,
		decimal? iDownTime = null,
		string iShiftID = null,
		byte? iSchedDownTime = null,
		byte? iCreateIncident = (byte)0,
		byte? iCopyLineTrans = (byte)0,
		string iUsrNum = null,
		int? iUsrSeq = null)
		{
			FSSROStatType _iSROCopyLevel = iSROCopyLevel;
			FSSROStatType _iSROCopyCalledFrom = iSROCopyCalledFrom;
			FSSROTransTypeType _iSroCopyTransFrom = iSroCopyTransFrom;
			FSSROTransTypeType _iSroCopyTransTo = iSroCopyTransTo;
			FSIncNumType _iSroCopyFromKey = iSroCopyFromKey;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSROLine = iTemplateSROLine;
			LongListType _iSelectedOpers = iSelectedOpers;
			CustNumType _iCustNum = iCustNum;
			CustSeqType _iCustSeq = iCustSeq;
			DateTimeType _iDate = iDate;
			FSPartnerType _iBillMgr = iBillMgr;
			DescriptionType _iSRODesc = iSRODesc;
			SerNumType _iSerNum = iSerNum;
			WhseType _iWhse = iWhse;
			ItemType _iItemNum = iItemNum;
			UMType _iUM = iUM;
			QtyUnitType _iQty = iQty;
			DescriptionType _iLineDesc = iLineDesc;
			FSPartnerType _iLeadPartner = iLeadPartner;
			ItemType _iCompItem = iCompItem;
			QtyUnitType _iCompQtyOrd = iCompQtyOrd;
			FSSRONumType _oSRONum = oSRONum;
			FSSROLineType _oSROLine = oSROLine;
			FSSROOperType _oSROOper = oSROOper;
			Infobar _Infobar = Infobar;
			ListYesNoType _iKeepOperNums = iKeepOperNums;
			AnyRefTypeType _iFromRefType = iFromRefType;
			FSRefNumType _iFromRefNum = iFromRefNum;
			FSRefLineType _iFromRefLine = iFromRefLine;
			FSRefReleaseType _iFromRefRelease = iFromRefRelease;
			ListYesNoType _iUseSroWhse = iUseSroWhse;
			FSSRONumType _iSRONum = iSRONum;
			FSCompIdType _iConfigCompId = iConfigCompId;
			FSSROStatType _iSroStat = iSroStat;
			FSRegionType _iRegion = iRegion;
			ListYesNoType _iChkShowAllOpers = iChkShowAllOpers;
			ListYesNoType _iKeepLineNums = iKeepLineNums;
			ListYesNoType _iUseAllOpers = iUseAllOpers;
			SiteType _iToSite = iToSite;
			FSSeqType _iSeq = iSeq;
			CustPoType _iCustPo = iCustPo;
			DateTimeType _iStartDate = iStartDate;
			FixedHoursType _iDuration = iDuration;
			CustItemType _iCustItem = iCustItem;
			DateTimeType _iMaintDate = iMaintDate;
			FixedHoursType _iDownTime = iDownTime;
			ApsShiftType _iShiftID = iShiftID;
			ListYesNoType _iSchedDownTime = iSchedDownTime;
			ListYesNoType _iCreateIncident = iCreateIncident;
			ListYesNoType _iCopyLineTrans = iCopyLineTrans;
			FSUsrNumType _iUsrNum = iUsrNum;
			FSUsrSeqType _iUsrSeq = iUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyCreateSroSp";
				
				appDB.AddCommandParameter(cmd, "iSROCopyLevel", _iSROCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROCopyCalledFrom", _iSROCopyCalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransFrom", _iSroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransTo", _iSroCopyTransTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyFromKey", _iSroCopyFromKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSROLine", _iTemplateSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSelectedOpers", _iSelectedOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustSeq", _iCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDate", _iDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillMgr", _iBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSRODesc", _iSRODesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItemNum", _iItemNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUM", _iUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLineDesc", _iLineDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLeadPartner", _iLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompItem", _iCompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompQtyOrd", _iCompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSRONum", _oSRONum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSROLine", _oSROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSROOper", _oSROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iKeepOperNums", _iKeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefType", _iFromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefNum", _iFromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefLine", _iFromRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefRelease", _iFromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUseSroWhse", _iUseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSRONum", _iSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iConfigCompId", _iConfigCompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroStat", _iSroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iRegion", _iRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iChkShowAllOpers", _iChkShowAllOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iKeepLineNums", _iKeepLineNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUseAllOpers", _iUseAllOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSite", _iToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSeq", _iSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustPo", _iCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartDate", _iStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDuration", _iDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustItem", _iCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMaintDate", _iMaintDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDownTime", _iDownTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iShiftID", _iShiftID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSchedDownTime", _iSchedDownTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCreateIncident", _iCreateIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCopyLineTrans", _iCopyLineTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUsrNum", _iUsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUsrSeq", _iUsrSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSRONum = _oSRONum;
				oSROLine = _oSROLine;
				oSROOper = _oSROOper;
				Infobar = _Infobar;
				
				return (Severity, oSRONum, oSROLine, oSROOper, Infobar);
			}
		}
	}
}
