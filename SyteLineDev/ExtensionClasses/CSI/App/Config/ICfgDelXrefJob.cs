//PROJECT NAME: Config
//CLASS NAME: ICfgDelXrefJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgDelXrefJob
	{
		(int? ReturnCode,
			string Infobar) CfgDelXrefJobSp(
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			string Infobar);
	}
}

