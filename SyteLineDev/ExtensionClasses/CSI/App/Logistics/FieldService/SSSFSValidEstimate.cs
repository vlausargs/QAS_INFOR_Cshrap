//PROJECT NAME: Logistics
//CLASS NAME: SSSFSValidEstimate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSValidEstimate : ISSSFSValidEstimate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSValidEstimate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSValidEstimateSp(
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			string iCodeField,
			string iCodeFieldName,
			string Infobar)
		{
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			StringType _iCodeField = iCodeField;
			StringType _iCodeFieldName = iCodeFieldName;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSValidEstimateSp";
				
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCodeField", _iCodeField, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCodeFieldName", _iCodeFieldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
