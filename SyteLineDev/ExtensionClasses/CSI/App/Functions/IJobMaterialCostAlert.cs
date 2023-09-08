//PROJECT NAME: Data
//CLASS NAME: IJobMaterialCostAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobMaterialCostAlert
	{
		(int? ReturnCode,
			string Infobar) JobMaterialCostAlertSp(
			string AJob,
			int? ASuffix,
			decimal? CurrentItemCost,
			decimal? AcutalCost,
			string Infobar);
	}
}

