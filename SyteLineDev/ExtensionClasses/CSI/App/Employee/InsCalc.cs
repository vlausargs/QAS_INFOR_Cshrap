//PROJECT NAME: Employee
//CLASS NAME: InsCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class InsCalc : IInsCalc
	{
		readonly IApplicationDB appDB;

		public InsCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			decimal? EmpinsCost,
			decimal? EmpinsCompCntr,
			string Infobar) InsCalcSp(
			string EmpinsEmpNum,
			decimal? EmpinsAmount,
			decimal? EmpinsCost,
			decimal? EmpinsCompCntr,
			string EmpinsCode,
			string Infobar)
		{
			EmpNumType _EmpinsEmpNum = EmpinsEmpNum;
			InsuranceAmountType _EmpinsAmount = EmpinsAmount;
			InsuranceCostType _EmpinsCost = EmpinsCost;
			InsuranceCompContType _EmpinsCompCntr = EmpinsCompCntr;
			InsuranceCodeType _EmpinsCode = EmpinsCode;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsCalcSp";

				appDB.AddCommandParameter(cmd, "EmpinsEmpNum", _EmpinsEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpinsAmount", _EmpinsAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpinsCost", _EmpinsCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpinsCompCntr", _EmpinsCompCntr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpinsCode", _EmpinsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				EmpinsCost = _EmpinsCost;
				EmpinsCompCntr = _EmpinsCompCntr;
				Infobar = _Infobar;

				return (Severity, EmpinsCost, EmpinsCompCntr, Infobar);
			}
		}
	}
}
