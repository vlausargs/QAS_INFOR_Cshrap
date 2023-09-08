//PROJECT NAME: Codes
//CLASS NAME: IGetFileServerProperty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetFileServerProperty
	{
		(int? ReturnCode, string ServerType,
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
		string Infobar);
	}
}

