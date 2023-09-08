//PROJECT NAME: Codes
//CLASS NAME: IdentifyCustomerPortalUserType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class IdentifyCustomerPortalUserType : IIdentifyCustomerPortalUserType
	{
		readonly IApplicationDB appDB;
		
		
		public IdentifyCustomerPortalUserType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? IsBTB,
		string Infobar) IdentifyCustomerPortalUserTypeSp(string Username,
		int? IsBTB,
		string Infobar)
		{
			UsernameType _Username = Username;
			ListYesNoType _IsBTB = IsBTB;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IdentifyCustomerPortalUserTypeSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsBTB", _IsBTB, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsBTB = _IsBTB;
				Infobar = _Infobar;
				
				return (Severity, IsBTB, Infobar);
			}
		}
	}
}
