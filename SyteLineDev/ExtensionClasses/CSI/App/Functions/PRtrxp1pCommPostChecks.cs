//PROJECT NAME: Data
//CLASS NAME: PRtrxp1pCommPostChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PRtrxp1pCommPostChecks : IPRtrxp1pCommPostChecks
	{
		readonly IApplicationDB appDB;
		
		public PRtrxp1pCommPostChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PRtrxp1pCommPostChecksSp(
			string pPrtrxEmpNum,
			DateTime? pPrtrxCheckDate,
			int? pPrtrxCheckNum,
			string pDeptUnit,
			string Infobar)
		{
			EmpNumType _pPrtrxEmpNum = pPrtrxEmpNum;
			DateType _pPrtrxCheckDate = pPrtrxCheckDate;
			PrCheckNumType _pPrtrxCheckNum = pPrtrxCheckNum;
			UnitCode1Type _pDeptUnit = pDeptUnit;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxp1pCommPostChecksSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxEmpNum", _pPrtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrtrxCheckDate", _pPrtrxCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrtrxCheckNum", _pPrtrxCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDeptUnit", _pDeptUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
