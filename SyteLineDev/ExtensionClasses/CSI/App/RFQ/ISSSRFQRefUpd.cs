//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQRefUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQRefUpd
	{
		(int? ReturnCode,
			string Infobar) SSSRFQRefUpdSp(
			string RFQNum,
			int? RFQLine,
			string Infobar);
	}
}

