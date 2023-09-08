//PROJECT NAME: Finance
//CLASS NAME: ApJour.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class ApJour : IApJour
	{
		readonly IApplicationDB appDB;
		
		public ApJour(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) ApJourSp(
			string JournalID,
			string stat,
			int? PreRegister,
			string VendNum,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string InfoBar)
		{
			JournalIdType _JournalID = JournalID;
			VchPrStatusType _stat = stat;
			PreRegisterType _PreRegister = PreRegister;
			VendNumType _VendNum = VendNum;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApJourSp";
				
				appDB.AddCommandParameter(cmd, "JournalID", _JournalID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "stat", _stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreRegister", _PreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
