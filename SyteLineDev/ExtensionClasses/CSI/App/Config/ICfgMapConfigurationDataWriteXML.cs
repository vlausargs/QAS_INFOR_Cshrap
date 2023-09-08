//PROJECT NAME: Config
//CLASS NAME: ICfgMapConfigurationDataWriteXML.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgMapConfigurationDataWriteXML
	{
		(int? ReturnCode, string Infobar) CfgMapConfigurationDataWriteXMLSp(string TableName,
		string XMLString,
		string Infobar);
	}
}

