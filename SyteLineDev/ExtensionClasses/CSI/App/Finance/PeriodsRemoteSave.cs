//PROJECT NAME: Finance
//CLASS NAME: PeriodsRemoteSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsRemoteSave : IPeriodsRemoteSave
	{
		readonly IApplicationDB appDB;
		
		public PeriodsRemoteSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PeriodsRemoteSaveSp(
			string pMode,
			int? FiscalYear,
			DateTime? PerStart1,
			DateTime? PerStart2,
			DateTime? PerStart3,
			DateTime? PerStart4,
			DateTime? PerStart5,
			DateTime? PerStart6,
			DateTime? PerStart7,
			DateTime? PerStart8,
			DateTime? PerStart9,
			DateTime? PerStart10,
			DateTime? PerStart11,
			DateTime? PerStart12,
			DateTime? PerStart13,
			DateTime? PerEnd1,
			DateTime? PerEnd2,
			DateTime? PerEnd3,
			DateTime? PerEnd4,
			DateTime? PerEnd5,
			DateTime? PerEnd6,
			DateTime? PerEnd7,
			DateTime? PerEnd8,
			DateTime? PerEnd9,
			DateTime? PerEnd10,
			DateTime? PerEnd11,
			DateTime? PerEnd12,
			DateTime? PerEnd13,
			string PerStat1,
			string PerStat2,
			string PerStat3,
			string PerStat4,
			string PerStat5,
			string PerStat6,
			string PerStat7,
			string PerStat8,
			string PerStat9,
			string PerStat10,
			string PerStat11,
			string PerStat12,
			string PerStat13,
			int? CurPer,
			int? Closed,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null,
			string UETListPairs = null)
		{
			InfobarType _pMode = pMode;
			FiscalYearType _FiscalYear = FiscalYear;
			DateType _PerStart1 = PerStart1;
			DateType _PerStart2 = PerStart2;
			DateType _PerStart3 = PerStart3;
			DateType _PerStart4 = PerStart4;
			DateType _PerStart5 = PerStart5;
			DateType _PerStart6 = PerStart6;
			DateType _PerStart7 = PerStart7;
			DateType _PerStart8 = PerStart8;
			DateType _PerStart9 = PerStart9;
			DateType _PerStart10 = PerStart10;
			DateType _PerStart11 = PerStart11;
			DateType _PerStart12 = PerStart12;
			DateType _PerStart13 = PerStart13;
			DateType _PerEnd1 = PerEnd1;
			DateType _PerEnd2 = PerEnd2;
			DateType _PerEnd3 = PerEnd3;
			DateType _PerEnd4 = PerEnd4;
			DateType _PerEnd5 = PerEnd5;
			DateType _PerEnd6 = PerEnd6;
			DateType _PerEnd7 = PerEnd7;
			DateType _PerEnd8 = PerEnd8;
			DateType _PerEnd9 = PerEnd9;
			DateType _PerEnd10 = PerEnd10;
			DateType _PerEnd11 = PerEnd11;
			DateType _PerEnd12 = PerEnd12;
			DateType _PerEnd13 = PerEnd13;
			PeriodStatusType _PerStat1 = PerStat1;
			PeriodStatusType _PerStat2 = PerStat2;
			PeriodStatusType _PerStat3 = PerStat3;
			PeriodStatusType _PerStat4 = PerStat4;
			PeriodStatusType _PerStat5 = PerStat5;
			PeriodStatusType _PerStat6 = PerStat6;
			PeriodStatusType _PerStat7 = PerStat7;
			PeriodStatusType _PerStat8 = PerStat8;
			PeriodStatusType _PerStat9 = PerStat9;
			PeriodStatusType _PerStat10 = PerStat10;
			PeriodStatusType _PerStat11 = PerStat11;
			PeriodStatusType _PerStat12 = PerStat12;
			PeriodStatusType _PerStat13 = PerStat13;
			FinPeriodType _CurPer = CurPer;
			ListYesNoType _Closed = Closed;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			VeryLongListType _UETListPairs = UETListPairs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PeriodsRemoteSaveSp";
				
				appDB.AddCommandParameter(cmd, "pMode", _pMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart1", _PerStart1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart2", _PerStart2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart3", _PerStart3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart4", _PerStart4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart5", _PerStart5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart6", _PerStart6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart7", _PerStart7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart8", _PerStart8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart9", _PerStart9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart10", _PerStart10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart11", _PerStart11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart12", _PerStart12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart13", _PerStart13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd1", _PerEnd1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd2", _PerEnd2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd3", _PerEnd3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd4", _PerEnd4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd5", _PerEnd5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd6", _PerEnd6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd7", _PerEnd7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd8", _PerEnd8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd9", _PerEnd9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd10", _PerEnd10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd11", _PerEnd11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd12", _PerEnd12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd13", _PerEnd13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat1", _PerStat1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat2", _PerStat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat3", _PerStat3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat4", _PerStat4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat5", _PerStat5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat6", _PerStat6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat7", _PerStat7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat8", _PerStat8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat9", _PerStat9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat10", _PerStat10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat11", _PerStat11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat12", _PerStat12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStat13", _PerStat13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurPer", _CurPer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Closed", _Closed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
