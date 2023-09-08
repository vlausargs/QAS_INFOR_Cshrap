//PROJECT NAME: Data
//CLASS NAME: IJxReq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJxReq
	{
		(int? ReturnCode,
			string PAction,
			string Infobar) JxReqSp(
			string PReqNum,
			int? PReqLine,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PAction,
			string Infobar);
	}
}

