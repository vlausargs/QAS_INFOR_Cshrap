//PROJECT NAME: Data
//CLASS NAME: VacCal1I.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VacCal1I : IVacCal1I
	{
		readonly IApplicationDB appDB;
		
		public VacCal1I(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? pDate,
			DateTime? pStart,
			DateTime? pEnd,
			DateTime? pServDate,
			int? pServYears,
			int? pJobDays,
			int? pServDays,
			int? pVacDays,
			decimal? pVac) VacCal1ISp(
			int? pEmpStatVacBnft,
			DateTime? pJobDate,
			string pPosClass,
			DateTime? pHighDate,
			DateTime? pLowDate,
			DateTime? pNextYearDate,
			DateTime? pDate,
			DateTime? pStart,
			DateTime? pEnd,
			DateTime? pServDate,
			int? pServYears,
			int? pJobDays,
			int? pServDays,
			int? pVacDays,
			decimal? pVac)
		{
			ListYesNoType _pEmpStatVacBnft = pEmpStatVacBnft;
			DateType _pJobDate = pJobDate;
			PosClassType _pPosClass = pPosClass;
			DateType _pHighDate = pHighDate;
			DateType _pLowDate = pLowDate;
			DateType _pNextYearDate = pNextYearDate;
			DateType _pDate = pDate;
			DateType _pStart = pStart;
			DateType _pEnd = pEnd;
			DateType _pServDate = pServDate;
			IntType _pServYears = pServYears;
			IntType _pJobDays = pJobDays;
			IntType _pServDays = pServDays;
			IntType _pVacDays = pVacDays;
			GenericFloatType _pVac = pVac;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VacCal1ISp";
				
				appDB.AddCommandParameter(cmd, "pEmpStatVacBnft", _pEmpStatVacBnft, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobDate", _pJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPosClass", _pPosClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHighDate", _pHighDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLowDate", _pLowDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNextYearDate", _pNextYearDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDate", _pDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pStart", _pStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pEnd", _pEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pServDate", _pServDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pServYears", _pServYears, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pJobDays", _pJobDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pServDays", _pServDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pVacDays", _pVacDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pVac", _pVac, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pDate = _pDate;
				pStart = _pStart;
				pEnd = _pEnd;
				pServDate = _pServDate;
				pServYears = _pServYears;
				pJobDays = _pJobDays;
				pServDays = _pServDays;
				pVacDays = _pVacDays;
				pVac = _pVac;
				
				return (Severity, pDate, pStart, pEnd, pServDate, pServYears, pJobDays, pServDays, pVacDays, pVac);
			}
		}
	}
}
