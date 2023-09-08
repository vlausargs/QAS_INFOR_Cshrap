//PROJECT NAME: Config
//CLASS NAME: ICfgGetDataType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetDataType
	{
		string CfgGetDataTypeFn(
			string Type);
	}
}

