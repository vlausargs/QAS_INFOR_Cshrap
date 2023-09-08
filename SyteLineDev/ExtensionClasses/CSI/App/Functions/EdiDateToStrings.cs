//PROJECT NAME: Data
//CLASS NAME: EdiDateToStrings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiDateToStrings : IEdiDateToStrings
	{
		readonly IApplicationDB appDB;
		
		public EdiDateToStrings(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string strDate,
			string strTime) EdiDateToStringsSp(
			DateTime? InputDate,
			string strDate,
			string strTime)
		{
			DateTimeType _InputDate = InputDate;
			StringType _strDate = strDate;
			StringType _strTime = strTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiDateToStringsSp";
				
				appDB.AddCommandParameter(cmd, "InputDate", _InputDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "strDate", _strDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "strTime", _strTime, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				strDate = _strDate;
				strTime = _strTime;
				
				return (Severity, strDate, strTime);
			}
		}
	}
}
