//PROJECT NAME: Finance
//CLASS NAME: GetCurPeriodBeginEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetCurPeriodBeginEndDate : IGetCurPeriodBeginEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public GetCurPeriodBeginEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? RStartDate,
		DateTime? REndDate,
		string Infobar) GetCurPeriodBeginEndDateSp(DateTime? RStartDate,
		DateTime? REndDate,
		string Infobar)
		{
			DateType _RStartDate = RStartDate;
			DateType _REndDate = REndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurPeriodBeginEndDateSp";
				
				appDB.AddCommandParameter(cmd, "RStartDate", _RStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "REndDate", _REndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RStartDate = _RStartDate;
				REndDate = _REndDate;
				Infobar = _Infobar;
				
				return (Severity, RStartDate, REndDate, Infobar);
			}
		}
	}
}
