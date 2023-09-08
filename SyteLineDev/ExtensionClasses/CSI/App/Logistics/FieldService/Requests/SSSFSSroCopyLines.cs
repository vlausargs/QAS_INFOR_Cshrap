//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCopyLines
	{
		(int? ReturnCode, int? oSROLine,
		int? oSROOper,
		string Infobar) SSSFSSroCopyLinesSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iSroCopyFromKey,
		string iToSroNum,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		string iSelectedOpers,
		DateTime? iDate,
		string iSerNum,
		string iItem,
		string iUM,
		decimal? iQty,
		string iLineDesc,
		string iChkShowAllOper,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		int? oSROLine,
		int? oSROOper,
		string Infobar,
		byte? iKeepOperNums = (byte)0,
		byte? iUseSroWhse = (byte)0,
		int? iConfigCompId = null,
		string iFromRefType = null,
		string iFromRefNum = null,
		int? iFromRefLine = null,
		int? iFromRefRelease = null,
		byte? iKeepLineNums = (byte)0,
		byte? iUseAllOpers = (byte)0,
		string iToSite = null,
		int? iSeq = 0,
		DateTime? iStartDate = null,
		string iCustItem = null,
		byte? iCopyLineTrans = (byte)0);
	}
	
	public class SSSFSSroCopyLines : ISSSFSSroCopyLines
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? oSROLine,
		int? oSROOper,
		string Infobar) SSSFSSroCopyLinesSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iSroCopyFromKey,
		string iToSroNum,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		string iSelectedOpers,
		DateTime? iDate,
		string iSerNum,
		string iItem,
		string iUM,
		decimal? iQty,
		string iLineDesc,
		string iChkShowAllOper,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		int? oSROLine,
		int? oSROOper,
		string Infobar,
		byte? iKeepOperNums = (byte)0,
		byte? iUseSroWhse = (byte)0,
		int? iConfigCompId = null,
		string iFromRefType = null,
		string iFromRefNum = null,
		int? iFromRefLine = null,
		int? iFromRefRelease = null,
		byte? iKeepLineNums = (byte)0,
		byte? iUseAllOpers = (byte)0,
		string iToSite = null,
		int? iSeq = 0,
		DateTime? iStartDate = null,
		string iCustItem = null,
		byte? iCopyLineTrans = (byte)0)
		{
			StringType _iSROCopyLevel = iSROCopyLevel;
			StringType _iSROCopyCalledFrom = iSROCopyCalledFrom;
			StringType _iSroCopyTransFrom = iSroCopyTransFrom;
			StringType _iSroCopyTransTo = iSroCopyTransTo;
			StringType _iSroCopyFromKey = iSroCopyFromKey;
			FSSRONumType _iToSroNum = iToSroNum;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSroLine = iTemplateSroLine;
			LongListType _iSelectedOpers = iSelectedOpers;
			DateTimeType _iDate = iDate;
			SerNumType _iSerNum = iSerNum;
			ItemType _iItem = iItem;
			UMType _iUM = iUM;
			QtyUnitType _iQty = iQty;
			DescriptionType _iLineDesc = iLineDesc;
			StringType _iChkShowAllOper = iChkShowAllOper;
			FSPartnerType _iLeadPartner = iLeadPartner;
			ItemType _iCompItem = iCompItem;
			QtyUnitType _iCompQtyOrd = iCompQtyOrd;
			FSSROLineType _oSROLine = oSROLine;
			FSSROOperType _oSROOper = oSROOper;
			InfobarType _Infobar = Infobar;
			ListYesNoType _iKeepOperNums = iKeepOperNums;
			ListYesNoType _iUseSroWhse = iUseSroWhse;
			FSCompIdType _iConfigCompId = iConfigCompId;
			AnyRefTypeType _iFromRefType = iFromRefType;
			FSRefNumType _iFromRefNum = iFromRefNum;
			FSRefLineType _iFromRefLine = iFromRefLine;
			FSRefReleaseType _iFromRefRelease = iFromRefRelease;
			ListYesNoType _iKeepLineNums = iKeepLineNums;
			ListYesNoType _iUseAllOpers = iUseAllOpers;
			SiteType _iToSite = iToSite;
			FSSeqType _iSeq = iSeq;
			DateTimeType _iStartDate = iStartDate;
			CustItemType _iCustItem = iCustItem;
			ListYesNoType _iCopyLineTrans = iCopyLineTrans;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyLinesSp";
				
				appDB.AddCommandParameter(cmd, "iSROCopyLevel", _iSROCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROCopyCalledFrom", _iSROCopyCalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransFrom", _iSroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransTo", _iSroCopyTransTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyFromKey", _iSroCopyFromKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroNum", _iToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroLine", _iTemplateSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSelectedOpers", _iSelectedOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDate", _iDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUM", _iUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLineDesc", _iLineDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iChkShowAllOper", _iChkShowAllOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLeadPartner", _iLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompItem", _iCompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompQtyOrd", _iCompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSROLine", _oSROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSROOper", _oSROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iKeepOperNums", _iKeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUseSroWhse", _iUseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iConfigCompId", _iConfigCompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefType", _iFromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefNum", _iFromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefLine", _iFromRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefRelease", _iFromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iKeepLineNums", _iKeepLineNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUseAllOpers", _iUseAllOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSite", _iToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSeq", _iSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartDate", _iStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustItem", _iCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCopyLineTrans", _iCopyLineTrans, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSROLine = _oSROLine;
				oSROOper = _oSROOper;
				Infobar = _Infobar;
				
				return (Severity, oSROLine, oSROOper, Infobar);
			}
		}
	}
}
