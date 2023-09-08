//PROJECT NAME: Production
//CLASS NAME: IApsDelTPLN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsDelTPLN
	{
		int? ApsDelTPLNSp(
			string OrderId);
	}
}

