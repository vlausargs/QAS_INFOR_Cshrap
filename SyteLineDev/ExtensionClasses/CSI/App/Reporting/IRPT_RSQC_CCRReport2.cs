//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_CCRReport2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_CCRReport2
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_CCRReport2Sp(
			int? RcvrNum = null);
	}
}

