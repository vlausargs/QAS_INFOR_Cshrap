//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigRcrRemove.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigRcrRemove : ISSSFSUnitConfigRcrRemove
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitConfigRcrRemove(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSUnitConfigRcrRemoveSp(
			int? iCompID,
			DateTime? iRemoveDate,
			string iReason,
			string Infobar,
			string iSroNum = null,
			int? iSroLine = null,
			int? iSroOper = null,
			int? iTransNum = null)
		{
			FSCompIdType _iCompID = iCompID;
			DateType _iRemoveDate = iRemoveDate;
			ReasonCodeType _iReason = iReason;
			Infobar _Infobar = Infobar;
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			FSSROTransNumType _iTransNum = iTransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigRcrRemoveSp";
				
				appDB.AddCommandParameter(cmd, "iCompID", _iCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iRemoveDate", _iRemoveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iReason", _iReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransNum", _iTransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
