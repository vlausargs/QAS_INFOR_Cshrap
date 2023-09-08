//PROJECT NAME: Production
//CLASS NAME: PmfFmUpdFormulaFromJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmUpdFormulaFromJob
	{
		(int? ReturnCode, string Infobar) PmfFmUpdFormulaFromJobSp(string Infobar,
		                                                           Guid? FormulaRowPointer);
	}
	
	public class PmfFmUpdFormulaFromJob : IPmfFmUpdFormulaFromJob
	{
		readonly IApplicationDB appDB;
		
		public PmfFmUpdFormulaFromJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmfFmUpdFormulaFromJobSp(string Infobar,
		                                                                  Guid? FormulaRowPointer)
		{
			InfobarType _Infobar = Infobar;
			RowPointer _FormulaRowPointer = FormulaRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmUpdFormulaFromJobSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FormulaRowPointer", _FormulaRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
