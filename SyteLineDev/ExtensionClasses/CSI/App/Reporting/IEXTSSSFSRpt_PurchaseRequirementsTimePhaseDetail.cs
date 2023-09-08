//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail
	{
		ICollectionLoadResponse EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailFn(
			string Item,
			string WhseStarting,
			string WhseEnding);
	}
}

