//PROJECT NAME: Production
//CLASS NAME: IRSQC_CanCloseProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CanCloseProcess
	{
		(int? ReturnCode, string can_close) RSQC_CanCloseProcessSp(string flow_num,
		string can_close);
	}
}

