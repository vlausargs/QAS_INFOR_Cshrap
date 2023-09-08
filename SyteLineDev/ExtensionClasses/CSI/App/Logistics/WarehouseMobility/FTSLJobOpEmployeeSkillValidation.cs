//PROJECT NAME: Logistics
//CLASS NAME: FTSLJobOpEmployeeSkillValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLJobOpEmployeeSkillValidation : IFTSLJobOpEmployeeSkillValidation
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLJobOpEmployeeSkillValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FTSLJobOpEmployeeSkillValidationSp(string EmpNum,
		string Job,
		int? Suffix,
		int? Operation,
		string Infobar,
		DateTime? PunchDate,
		string ERPQueryResponseString)
		{
			EmpNumType _EmpNum = EmpNum;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;
			InfobarType _Infobar = Infobar;
			DateType _PunchDate = PunchDate;
			XMLStringType _ERPQueryResponseString = ERPQueryResponseString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLJobOpEmployeeSkillValidationSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PunchDate", _PunchDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERPQueryResponseString", _ERPQueryResponseString, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
