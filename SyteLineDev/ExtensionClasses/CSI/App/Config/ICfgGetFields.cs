//PROJECT NAME: Config
//CLASS NAME: ICfgGetFields.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetFields
	{
		int? CfgGetFieldsSp(string pFile,
		int? pInclude);
	}
}

