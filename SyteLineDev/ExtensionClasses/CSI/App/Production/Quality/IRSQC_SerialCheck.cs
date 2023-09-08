//PROJECT NAME: Production
//CLASS NAME: IRSQC_SerialCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SerialCheck
	{
		(int? ReturnCode, int? o_ErrorCode,
		string o_Messages,
		string Infobar) RSQC_SerialCheckSp(string SerNum,
		int? RcvNum,
		int? o_ErrorCode,
		string o_Messages,
		string Infobar);
	}
}

