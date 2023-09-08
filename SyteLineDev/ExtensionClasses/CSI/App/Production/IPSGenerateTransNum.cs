//PROJECT NAME: Production
//CLASS NAME: IPSGenerateTransNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPSGenerateTransNum
	{
		(int? ReturnCode, decimal? TJobtranTransNum,
		string Infobar) PSGenerateTransNumSp(Guid? SessionID,
		decimal? TJobtranTransNum,
		string Infobar);
	}
}

