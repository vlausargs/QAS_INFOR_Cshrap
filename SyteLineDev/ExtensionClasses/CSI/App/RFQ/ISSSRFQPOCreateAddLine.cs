//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQPOCreateAddLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQPOCreateAddLine
	{
		(int? ReturnCode, string Infobar) SSSRFQPOCreateAddLineSp(string RFQNum,
		int? RFQLine,
		string Infobar);
	}
}

