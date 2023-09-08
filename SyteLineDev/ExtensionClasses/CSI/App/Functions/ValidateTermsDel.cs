//PROJECT NAME: Data
//CLASS NAME: ValidateTermsDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateTermsDel : IValidateTermsDel
	{
		readonly IApplicationDB appDB;
		
		public ValidateTermsDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValidateTermsDelSp(
			string PTermsCode,
			string Infobar)
		{
			TermsCodeType _PTermsCode = PTermsCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateTermsDelSp";
				
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
