//PROJECT NAME: Config
//CLASS NAME: ICfgProcessJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgProcessJob
	{
		(int? ReturnCode,
			string Infobar) CfgProcessJobSp(
			string pJob,
			int? pSuffix,
			string pType,
			string pConfigId,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			int? pCreateJob,
			int? pUpdatePrice,
			string pRunFrom,
			string Infobar);
	}
}

