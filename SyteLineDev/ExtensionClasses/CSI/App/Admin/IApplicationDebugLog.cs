//PROJECT NAME: Admin
//CLASS NAME: IApplicationDebugLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IApplicationDebugLog
	{
		(int? ReturnCode, string Infobar) ApplicationDebugLogSp(string SourceType = "",
		string SourceName = "",
		string MessageName = "",
		string MessageDetail = "",
		int? ProcID = 0,
		int? PurgeData = 0,
		string Infobar = "");
	}
}

