//PROJECT NAME: Employee
//CLASS NAME: ValidateDirDepRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IValidateDirDepRank
	{
		(int? ReturnCode, string Infobar) ValidateDirDepRankSp(string EmpNum,
		short? NewRank,
		string Infobar = null);
	}
	
	public class ValidateDirDepRank : IValidateDirDepRank
	{
		readonly IApplicationDB appDB;
		
		public ValidateDirDepRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateDirDepRankSp(string EmpNum,
		short? NewRank,
		string Infobar = null)
		{
			EmpNumType _EmpNum = EmpNum;
			EmpPrbankRankType _NewRank = NewRank;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateDirDepRankSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRank", _NewRank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
