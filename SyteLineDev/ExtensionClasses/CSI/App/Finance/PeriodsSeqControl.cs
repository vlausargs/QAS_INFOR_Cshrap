//PROJECT NAME: Finance
//CLASS NAME: PeriodsSeqControl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsSeqControl : IPeriodsSeqControl
	{
		readonly IApplicationDB appDB;
		
		public PeriodsSeqControl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PeriodsSeqControlFn(
			int? PeriodsSeqFiscalYear,
			string PeriodsSeqJourControlPrefix,
			int? Period,
			string Site)
		{
			FiscalYearType _PeriodsSeqFiscalYear = PeriodsSeqFiscalYear;
			JourControlPrefixType _PeriodsSeqJourControlPrefix = PeriodsSeqJourControlPrefix;
			FinPeriodType _Period = Period;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PeriodsSeqControl](@PeriodsSeqFiscalYear, @PeriodsSeqJourControlPrefix, @Period, @Site)";
				
				appDB.AddCommandParameter(cmd, "PeriodsSeqFiscalYear", _PeriodsSeqFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodsSeqJourControlPrefix", _PeriodsSeqJourControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
