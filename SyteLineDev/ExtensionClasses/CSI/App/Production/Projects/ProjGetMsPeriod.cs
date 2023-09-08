//PROJECT NAME: Production
//CLASS NAME: ProjGetMsPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjGetMsPeriod : IProjGetMsPeriod
	{
		readonly IApplicationDB appDB;
		
		
		public ProjGetMsPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CurrentPeriod,
		DateTime? CurrentPeriodStart,
		DateTime? CurrentPeriodEnd,
		string Infobar) ProjGetMsPeriodSp(DateTime? MsPlanDate,
		DateTime? MsActDate,
		int? CurrentPeriod,
		DateTime? CurrentPeriodStart,
		DateTime? CurrentPeriodEnd,
		string Infobar)
		{
			DateType _MsPlanDate = MsPlanDate;
			DateType _MsActDate = MsActDate;
			FinPeriodType _CurrentPeriod = CurrentPeriod;
			DateType _CurrentPeriodStart = CurrentPeriodStart;
			DateType _CurrentPeriodEnd = CurrentPeriodEnd;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjGetMsPeriodSp";
				
				appDB.AddCommandParameter(cmd, "MsPlanDate", _MsPlanDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsActDate", _MsActDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriod", _CurrentPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrentPeriodStart", _CurrentPeriodStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrentPeriodEnd", _CurrentPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrentPeriod = _CurrentPeriod;
				CurrentPeriodStart = _CurrentPeriodStart;
				CurrentPeriodEnd = _CurrentPeriodEnd;
				Infobar = _Infobar;
				
				return (Severity, CurrentPeriod, CurrentPeriodStart, CurrentPeriodEnd, Infobar);
			}
		}
	}
}
