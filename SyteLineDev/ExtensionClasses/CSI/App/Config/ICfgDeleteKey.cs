//PROJECT NAME: Config
//CLASS NAME: ICfgDeleteKey.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgDeleteKey
	{
		(int? ReturnCode,
			string Infobar) CfgDeleteKeySp(
			string TableName,
			string ColumnName,
			string Key,
			string Infobar);
	}
}

