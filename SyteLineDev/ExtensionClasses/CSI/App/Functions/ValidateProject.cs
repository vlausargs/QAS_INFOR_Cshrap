//PROJECT NAME: Data
//CLASS NAME: ValidateProject.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateProject : IValidateProject
	{
		readonly IApplicationDB appDB;
		
		public ValidateProject(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValidateProjectSp(
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PItem,
			string Infobar)
		{
			JobPoReqNumType _PRefNum = PRefNum;
			SuffixPoReqLineType _PRefLineSuf = PRefLineSuf;
			OperNumPoReleaseType _PRefRelease = PRefRelease;
			ItemType _PItem = PItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateProjectSp";
				
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
