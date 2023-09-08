//PROJECT NAME: Logistics
//CLASS NAME: ValidateInvLength.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateInvLength : IValidateInvLength
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateInvLength(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateInvLengthSp(int? InvNumLen,
		string Infobar)
		{
			InvNumLength _InvNumLen = InvNumLen;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateInvLengthSp";
				
				appDB.AddCommandParameter(cmd, "InvNumLen", _InvNumLen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
