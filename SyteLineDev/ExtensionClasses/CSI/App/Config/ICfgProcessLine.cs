//PROJECT NAME: Config
//CLASS NAME: ICfgProcessLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgProcessLine
	{
		(int? ReturnCode,
			int? pIPNCreated,
			string Infobar) CfgProcessLineSp(
			string pCoNum,
			int? pCoLine,
			string pConfigId,
			string pType,
			string pRunMode,
			int? pCreateJob,
			int? pUpdatePrice,
			int? pIPNCreated,
			string Infobar);
	}
}

