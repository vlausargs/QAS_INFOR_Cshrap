//PROJECT NAME: Data
//CLASS NAME: ICoCreditCheckMessage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoCreditCheckMessage
	{
		(int? ReturnCode,
			string Infobar) CoCreditCheckMessageSp(
			string CoNum,
			decimal? TotalPrice,
			string Infobar);
	}
}

