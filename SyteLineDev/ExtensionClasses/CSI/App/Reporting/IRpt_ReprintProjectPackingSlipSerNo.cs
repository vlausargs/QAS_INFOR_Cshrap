//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectPackingSlipSerNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectPackingSlipSerNo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectPackingSlipSerNoSp(
			string proj_num,
			int? task_num,
			int? seq);
	}
}

