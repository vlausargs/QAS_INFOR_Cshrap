//PROJECT NAME: Data
//CLASS NAME: JP_CutoffDateForTermsCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JP_CutoffDateForTermsCode : IJP_CutoffDateForTermsCode
	{
		readonly IApplicationDB appDB;
		
		public JP_CutoffDateForTermsCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? JP_CutoffDateForTermsCodeFn(
			DateTime? Date,
			string pTermsCode)
		{
			GenericDateType _Date = Date;
			TermsCodeType _pTermsCode = pTermsCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JP_CutoffDateForTermsCode](@Date, @pTermsCode)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
