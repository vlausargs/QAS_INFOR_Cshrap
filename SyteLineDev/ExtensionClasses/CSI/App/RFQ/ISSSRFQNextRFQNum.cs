//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQNextRFQNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQNextRFQNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSRFQNextRFQNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

