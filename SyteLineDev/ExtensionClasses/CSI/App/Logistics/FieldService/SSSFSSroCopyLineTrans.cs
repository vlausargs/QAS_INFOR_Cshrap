//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyLineTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroCopyLineTrans : ISSSFSSroCopyLineTrans
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyLineTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroCopyLineTransSp(
			string iSroCopyLevel,
			string iSroCopyCalledFrom,
			string iToSroNum,
			int? iToSroLine,
			string iTemplateSroNum,
			int? iTemplateSroLine,
			string Infobar,
			int? iUseSroWhse = 0)
		{
			StringType _iSroCopyLevel = iSroCopyLevel;
			StringType _iSroCopyCalledFrom = iSroCopyCalledFrom;
			FSSRONumType _iToSroNum = iToSroNum;
			FSSROLineType _iToSroLine = iToSroLine;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSroLine = iTemplateSroLine;
			InfobarType _Infobar = Infobar;
			ListYesNoType _iUseSroWhse = iUseSroWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyLineTransSp";
				
				appDB.AddCommandParameter(cmd, "iSroCopyLevel", _iSroCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyCalledFrom", _iSroCopyCalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroNum", _iToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroLine", _iToSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroLine", _iTemplateSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iUseSroWhse", _iUseSroWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
