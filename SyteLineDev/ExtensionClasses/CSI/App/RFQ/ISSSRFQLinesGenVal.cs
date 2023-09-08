//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQLinesGenVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQLinesGenVal
	{
		(int? ReturnCode,
			string Infobar,
			string LastRFQNum,
			int? LastRFQLine,
			string ProductCode) SSSRFQLinesGenValSp(
			string Method,
			string Item,
			int? FromGenUtils,
			string Infobar,
			string LastRFQNum = null,
			int? LastRFQLine = null,
			string ProductCode = null);
	}
}

