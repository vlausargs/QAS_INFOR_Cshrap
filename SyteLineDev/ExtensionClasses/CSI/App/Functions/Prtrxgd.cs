//PROJECT NAME: Data
//CLASS NAME: Prtrxgd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxgd : IPrtrxgd
	{
		readonly IApplicationDB appDB;
		
		public Prtrxgd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PrtrxgdSp(
			string SEmployee,
			string EEmployee,
			string PEmplType,
			string PPrDelWhich,
			string Infobar,
			string PStartEmpCate = null,
			string PEndEmpCate = null)
		{
			EmpNumType _SEmployee = SEmployee;
			EmpNumType _EEmployee = EEmployee;
			LongListType _PEmplType = PEmplType;
			StringType _PPrDelWhich = PPrDelWhich;
			InfobarType _Infobar = Infobar;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxgdSp";
				
				appDB.AddCommandParameter(cmd, "SEmployee", _SEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEmployee", _EEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmplType", _PEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrDelWhich", _PPrDelWhich, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
