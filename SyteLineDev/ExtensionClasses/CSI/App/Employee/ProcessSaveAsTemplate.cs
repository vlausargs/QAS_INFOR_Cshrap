//PROJECT NAME: CSIEmployee
//CLASS NAME: ProcessSaveAsTemplate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IProcessSaveAsTemplate
	{
		(int? ReturnCode, string Infobar) ProcessSaveAsTemplateSp(Guid? ProcessRowPointer = null,
		string job_id = null,
		string dept = null,
		string div_num = null,
		string Infobar = null);
	}
	
	public class ProcessSaveAsTemplate : IProcessSaveAsTemplate
	{
		readonly IApplicationDB appDB;
		
		public ProcessSaveAsTemplate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProcessSaveAsTemplateSp(Guid? ProcessRowPointer = null,
		string job_id = null,
		string dept = null,
		string div_num = null,
		string Infobar = null)
		{
			RowPointerType _ProcessRowPointer = ProcessRowPointer;
			JobIdType _job_id = job_id;
			DeptType _dept = dept;
			DivNumType _div_num = div_num;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessSaveAsTemplateSp";
				
				appDB.AddCommandParameter(cmd, "ProcessRowPointer", _ProcessRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "job_id", _job_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "dept", _dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "div_num", _div_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
