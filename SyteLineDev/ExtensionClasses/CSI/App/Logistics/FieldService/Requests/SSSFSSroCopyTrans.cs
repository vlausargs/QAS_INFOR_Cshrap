//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCopyTrans
	{
		(int? ReturnCode, string Infobar) SSSFSSroCopyTransSp(string iSroCopyLevel,
		string iSroCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iToSroNum,
		int? iToSroLine,
		int? iToSroOper,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		int? iTemplateSroOper,
		string iCompItem,
		decimal? iCompQtyOrd,
		string Infobar,
		byte? iUseSroWhse = (byte)0,
		int? iConfigCompId = null);
	}
	
	public class SSSFSSroCopyTrans : ISSSFSSroCopyTrans
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSroCopyTransSp(string iSroCopyLevel,
		string iSroCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iToSroNum,
		int? iToSroLine,
		int? iToSroOper,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		int? iTemplateSroOper,
		string iCompItem,
		decimal? iCompQtyOrd,
		string Infobar,
		byte? iUseSroWhse = (byte)0,
		int? iConfigCompId = null)
		{
			StringType _iSroCopyLevel = iSroCopyLevel;
			StringType _iSroCopyCalledFrom = iSroCopyCalledFrom;
			StringType _iSroCopyTransFrom = iSroCopyTransFrom;
			StringType _iSroCopyTransTo = iSroCopyTransTo;
			FSSRONumType _iToSroNum = iToSroNum;
			FSSROLineType _iToSroLine = iToSroLine;
			FSSROOperType _iToSroOper = iToSroOper;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSroLine = iTemplateSroLine;
			FSSROOperType _iTemplateSroOper = iTemplateSroOper;
			ItemType _iCompItem = iCompItem;
			QtyUnitType _iCompQtyOrd = iCompQtyOrd;
			InfobarType _Infobar = Infobar;
			ListYesNoType _iUseSroWhse = iUseSroWhse;
			FSCompIdType _iConfigCompId = iConfigCompId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyTransSp";
				
				appDB.AddCommandParameter(cmd, "iSroCopyLevel", _iSroCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyCalledFrom", _iSroCopyCalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransFrom", _iSroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransTo", _iSroCopyTransTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroNum", _iToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroLine", _iToSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroOper", _iToSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroLine", _iTemplateSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroOper", _iTemplateSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompItem", _iCompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompQtyOrd", _iCompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iUseSroWhse", _iUseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iConfigCompId", _iConfigCompId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
