//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInspectionsCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInspectionsCopy : ISSSFSSROInspectionsCopy
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInspectionsCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSROInspectionsCopySp(
			string SroNum,
			int? SroLine,
			string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInspectionsCopySp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
