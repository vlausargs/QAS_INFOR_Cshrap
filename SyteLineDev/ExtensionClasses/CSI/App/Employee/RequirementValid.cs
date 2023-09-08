//PROJECT NAME: Employee
//CLASS NAME: RequirementValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class RequirementValid : IRequirementValid
	{
		readonly IApplicationDB appDB;
		
		
		public RequirementValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DerDescription,
		string Infobar) RequirementValidSp(string ReqType,
		string Requirement,
		string DerDescription,
		string Infobar)
		{
			PosReqTypeType _ReqType = ReqType;
			PosRequirementType _Requirement = Requirement;
			DescriptionType _DerDescription = DerDescription;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RequirementValidSp";
				
				appDB.AddCommandParameter(cmd, "ReqType", _ReqType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Requirement", _Requirement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDescription", _DerDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DerDescription = _DerDescription;
				Infobar = _Infobar;
				
				return (Severity, DerDescription, Infobar);
			}
		}
	}
}
