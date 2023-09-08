//PROJECT NAME: Codes
//CLASS NAME: GetFileServerProperty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetFileServerProperty : IGetFileServerProperty
	{
		readonly IApplicationDB appDB;
		
		
		public GetFileServerProperty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ServerType,
		string DomainName,
		int? Active,
		string SharedPath,
		string UserName,
		string UserPassword,
		string Infobar) GetFileServerPropertySP(string ServerName,
		string ServerType,
		string DomainName,
		int? Active,
		string SharedPath,
		string UserName,
		string UserPassword,
		string Infobar)
		{
			OSMachineNameType _ServerName = ServerName;
			FileServerTypeType _ServerType = ServerType;
			NetworkDomainNameType _DomainName = DomainName;
			ListYesNoType _Active = Active;
			LongDescType _SharedPath = SharedPath;
			UsernameType _UserName = UserName;
			EncryptedPasswordType _UserPassword = UserPassword;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFileServerPropertySP";
				
				appDB.AddCommandParameter(cmd, "ServerName", _ServerName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServerType", _ServerType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomainName", _DomainName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SharedPath", _SharedPath, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserPassword", _UserPassword, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ServerType = _ServerType;
				DomainName = _DomainName;
				Active = _Active;
				SharedPath = _SharedPath;
				UserName = _UserName;
				UserPassword = _UserPassword;
				Infobar = _Infobar;
				
				return (Severity, ServerType, DomainName, Active, SharedPath, UserName, UserPassword, Infobar);
			}
		}
	}
}
