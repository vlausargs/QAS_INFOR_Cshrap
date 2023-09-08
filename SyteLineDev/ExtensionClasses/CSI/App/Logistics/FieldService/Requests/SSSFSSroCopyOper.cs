//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCopyOper
	{
		(int? ReturnCode, int? oSROOper,
		string Infobar) SSSFSSroCopyOperSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iToSroNum,
		int? iToSroLine,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		string iSelectedOpers,
		DateTime? iDate,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		int? oSROOper,
		string Infobar,
		string iSroCopyFromKey = null,
		byte? iKeepOperNums = (byte)0,
		byte? iUseSroWhse = (byte)0,
		int? iConfigCompId = null,
		byte? iUseAllOpers = (byte)0,
		DateTime? iStartDate = null);
	}
	
	public class SSSFSSroCopyOper : ISSSFSSroCopyOper
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? oSROOper,
		string Infobar) SSSFSSroCopyOperSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iToSroNum,
		int? iToSroLine,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		string iSelectedOpers,
		DateTime? iDate,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		int? oSROOper,
		string Infobar,
		string iSroCopyFromKey = null,
		byte? iKeepOperNums = (byte)0,
		byte? iUseSroWhse = (byte)0,
		int? iConfigCompId = null,
		byte? iUseAllOpers = (byte)0,
		DateTime? iStartDate = null)
		{
			StringType _iSROCopyLevel = iSROCopyLevel;
			StringType _iSROCopyCalledFrom = iSROCopyCalledFrom;
			StringType _iSroCopyTransFrom = iSroCopyTransFrom;
			StringType _iSroCopyTransTo = iSroCopyTransTo;
			FSSRONumType _iToSroNum = iToSroNum;
			FSSROLineType _iToSroLine = iToSroLine;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSroLine = iTemplateSroLine;
			LongListType _iSelectedOpers = iSelectedOpers;
			DateTimeType _iDate = iDate;
			FSPartnerType _iLeadPartner = iLeadPartner;
			ItemType _iCompItem = iCompItem;
			QtyUnitType _iCompQtyOrd = iCompQtyOrd;
			FSSROOperType _oSROOper = oSROOper;
			InfobarType _Infobar = Infobar;
			FSIncNumType _iSroCopyFromKey = iSroCopyFromKey;
			ListYesNoType _iKeepOperNums = iKeepOperNums;
			ListYesNoType _iUseSroWhse = iUseSroWhse;
			FSCompIdType _iConfigCompId = iConfigCompId;
			ListYesNoType _iUseAllOpers = iUseAllOpers;
			DateTimeType _iStartDate = iStartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyOperSp";
				
				appDB.AddCommandParameter(cmd, "iSROCopyLevel", _iSROCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROCopyCalledFrom", _iSROCopyCalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransFrom", _iSroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransTo", _iSroCopyTransTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroNum", _iToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroLine", _iToSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroLine", _iTemplateSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSelectedOpers", _iSelectedOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDate", _iDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLeadPartner", _iLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompItem", _iCompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompQtyOrd", _iCompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSROOper", _oSROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iSroCopyFromKey", _iSroCopyFromKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iKeepOperNums", _iKeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUseSroWhse", _iUseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iConfigCompId", _iConfigCompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUseAllOpers", _iUseAllOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartDate", _iStartDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSROOper = _oSROOper;
				Infobar = _Infobar;
				
				return (Severity, oSROOper, Infobar);
			}
		}
	}
}
