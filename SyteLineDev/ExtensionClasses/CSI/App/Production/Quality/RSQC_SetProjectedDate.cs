//PROJECT NAME: Production
//CLASS NAME: RSQC_SetProjectedDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetProjectedDate : IRSQC_SetProjectedDate
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SetProjectedDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? projected_date) RSQC_SetProjectedDateSp(string flow_num,
		DateTime? projected_date)
		{
			QCDocNumType _flow_num = flow_num;
			DateTimeType _projected_date = projected_date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SetProjectedDateSp";
				
				appDB.AddCommandParameter(cmd, "flow_num", _flow_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "projected_date", _projected_date, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				projected_date = _projected_date;
				
				return (Severity, projected_date);
			}
		}
	}
}
