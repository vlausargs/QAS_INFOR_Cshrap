//PROJECT NAME: Config
//CLASS NAME: ICfgGetConfigId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetConfigId
	{
		string CfgGetConfigIdFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf);
	}
}

