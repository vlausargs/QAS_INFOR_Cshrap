//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQPOCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQPOCreate
	{
		(int? ReturnCode, string Infobar) SSSRFQPOCreateSp(string iPONum,
		string Infobar);
	}
}

