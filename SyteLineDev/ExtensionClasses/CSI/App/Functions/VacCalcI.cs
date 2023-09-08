//PROJECT NAME: Data
//CLASS NAME: VacCalcI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VacCalcI : IVacCalcI
	{
		readonly IApplicationDB appDB;
		
		public VacCalcI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pNoHrJob,
			int? pNoVacParms,
			decimal? pTVac,
			int? pActive,
			string Infobar) VacCalcISp(
			string pEmpNum,
			DateTime? pHighDate,
			DateTime? pLowDate,
			DateTime? pNextYearDate,
			int? pNoHrJobContinue = 1,
			int? pNoVacParmsContinue = 1,
			int? pNoHrJob = null,
			int? pNoVacParms = null,
			decimal? pTVac = null,
			int? pActive = null,
			string Infobar = null)
		{
			EmpNumType _pEmpNum = pEmpNum;
			DateType _pHighDate = pHighDate;
			DateType _pLowDate = pLowDate;
			DateType _pNextYearDate = pNextYearDate;
			ListYesNoType _pNoHrJobContinue = pNoHrJobContinue;
			ListYesNoType _pNoVacParmsContinue = pNoVacParmsContinue;
			ListYesNoType _pNoHrJob = pNoHrJob;
			ListYesNoType _pNoVacParms = pNoVacParms;
			GenericFloatType _pTVac = pTVac;
			ListYesNoType _pActive = pActive;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VacCalcISp";
				
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHighDate", _pHighDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLowDate", _pLowDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNextYearDate", _pNextYearDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNoHrJobContinue", _pNoHrJobContinue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNoVacParmsContinue", _pNoVacParmsContinue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNoHrJob", _pNoHrJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pNoVacParms", _pNoVacParms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pTVac", _pTVac, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pActive", _pActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pNoHrJob = _pNoHrJob;
				pNoVacParms = _pNoVacParms;
				pTVac = _pTVac;
				pActive = _pActive;
				Infobar = _Infobar;
				
				return (Severity, pNoHrJob, pNoVacParms, pTVac, pActive, Infobar);
			}
		}
	}
}
