//PROJECT NAME: Production
//CLASS NAME: IJobmatlObsChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobmatlObsChk
	{
		(int? ReturnCode, string Infobar) JobmatlObsChkSp(string PJob,
		int? PSuffix,
		int? OperStart = null,
		int? OperEnd = null,
		string Infobar = null);
	}
}

