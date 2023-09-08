//PROJECT NAME: Codes
//CLASS NAME: ValidateTaxRegNum1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class ValidateTaxRegNum1 : IValidateTaxRegNum1
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateTaxRegNum1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateTaxRegNum1Sp(string FormType,
		string Infobar)
		{
			StringType _FormType = FormType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateTaxRegNum1Sp";
				
				appDB.AddCommandParameter(cmd, "FormType", _FormType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
