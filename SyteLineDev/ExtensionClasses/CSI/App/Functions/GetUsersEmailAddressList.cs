//PROJECT NAME: Data
//CLASS NAME: GetUsersEmailAddressList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetUsersEmailAddressList : IGetUsersEmailAddressList
	{
		readonly IApplicationDB appDB;
		
		public GetUsersEmailAddressList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string EmailAddressList,
			string Infobar) GetUsersEmailAddressListSp(
			string UserList,
			string EmailAddressList = null,
			string Infobar = null)
		{
			EventVariableValueType _UserList = UserList;
			EventVariableValueType _EmailAddressList = EmailAddressList;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetUsersEmailAddressListSp";
				
				appDB.AddCommandParameter(cmd, "UserList", _UserList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailAddressList", _EmailAddressList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmailAddressList = _EmailAddressList;
				Infobar = _Infobar;
				
				return (Severity, EmailAddressList, Infobar);
			}
		}
	}
}
