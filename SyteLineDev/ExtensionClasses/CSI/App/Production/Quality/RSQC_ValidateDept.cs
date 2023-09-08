//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateDept.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateDept : IRSQC_ValidateDept
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ValidateDept(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description,
		string Infobar) RSQC_ValidateDeptSp(int? ValidateDept,
		string Dept,
		string Description,
		string Infobar)
		{
			ListYesNoType _ValidateDept = ValidateDept;
			DeptType _Dept = Dept;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateDeptSp";
				
				appDB.AddCommandParameter(cmd, "ValidateDept", _ValidateDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				Infobar = _Infobar;
				
				return (Severity, Description, Infobar);
			}
		}
	}
}
