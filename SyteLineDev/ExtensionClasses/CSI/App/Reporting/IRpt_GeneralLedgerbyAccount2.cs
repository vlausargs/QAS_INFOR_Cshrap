//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GeneralLedgerbyAccount2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GeneralLedgerbyAccount2
	{
		int? Rpt_GeneralLedgerbyAccount2Sp();
	}
}

