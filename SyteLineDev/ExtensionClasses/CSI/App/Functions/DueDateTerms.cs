//PROJECT NAME: Data
//CLASS NAME: DueDateTerms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DueDateTerms : IDueDateTerms
	{
		readonly IApplicationDB appDB;
		
		public DueDateTerms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? DueDateTermsFn(
			DateTime? DueDate,
			string TermsCode)
		{
			DateType _DueDate = DueDate;
			TermsCodeType _TermsCode = TermsCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DueDateTerms](@DueDate, @TermsCode)";
				
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
