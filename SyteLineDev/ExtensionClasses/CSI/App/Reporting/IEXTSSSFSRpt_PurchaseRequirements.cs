//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_PurchaseRequirements.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_PurchaseRequirements
	{
		int? EXTSSSFSRpt_PurchaseRequirementsSp(
			string Item,
			string WhseStarting,
			string WhseEnding,
			string SROStatus,
			int? ShowDepl);
	}
}

