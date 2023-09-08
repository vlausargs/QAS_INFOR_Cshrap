//PROJECT NAME: Finance
//CLASS NAME: IGlCmprPDoProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlCmprPDoProcess
	{
		(int? ReturnCode, int? RACompressed,
		string Infobar) GlCmprPDoProcessSp(Guid? ProcessId,
		string PCompressBy,
		string PCompressionLevel,
		int? PAnalyticalLedger,
		int? RACompressed,
		string Infobar);
	}
}

