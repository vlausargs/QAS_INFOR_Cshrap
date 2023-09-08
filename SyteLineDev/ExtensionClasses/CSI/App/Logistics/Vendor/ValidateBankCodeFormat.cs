//PROJECT NAME: Logistics
//CLASS NAME: ValidateBankCodeFormat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateBankCodeFormat : IValidateBankCodeFormat
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateBankCodeFormat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateBankCodeFormatSp(string BankCode,
		string EFTFormat,
		string Infobar)
		{
			BankCodeType _BankCode = BankCode;
			EFTFormatType _EFTFormat = EFTFormat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateBankCodeFormatSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFTFormat", _EFTFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
