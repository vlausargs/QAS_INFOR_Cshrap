//PROJECT NAME: Production
//CLASS NAME: PP_ParsedFormulaProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_ParsedFormulaProcess : IPP_ParsedFormulaProcess
	{
		readonly IApplicationDB appDB;
		
		public PP_ParsedFormulaProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Formula,
			string BigDSql,
			int? NeedParsed) PP_ParsedFormulaProcessSp(
			string OperType,
			string Job = null,
			int? UpdateFormula = 0,
			string Formula = null,
			string BigDSql = null,
			int? NeedParsed = null)
		{
			PP_OperationType2Type _OperType = OperType;
			JobType _Job = Job;
			ListYesNoType _UpdateFormula = UpdateFormula;
			PP_FormulaType _Formula = Formula;
			StringType _BigDSql = BigDSql;
			ListYesNoType _NeedParsed = NeedParsed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ParsedFormulaProcessSp";
				
				appDB.AddCommandParameter(cmd, "OperType", _OperType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateFormula", _UpdateFormula, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Formula", _Formula, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BigDSql", _BigDSql, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NeedParsed", _NeedParsed, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Formula = _Formula;
				BigDSql = _BigDSql;
				NeedParsed = _NeedParsed;
				
				return (Severity, Formula, BigDSql, NeedParsed);
			}
		}
	}
}
