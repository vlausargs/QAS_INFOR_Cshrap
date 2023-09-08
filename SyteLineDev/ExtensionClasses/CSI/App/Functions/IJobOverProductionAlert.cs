//PROJECT NAME: Data
//CLASS NAME: IJobOverProductionAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobOverProductionAlert
	{
		(int? ReturnCode,
			string Infobar) JobOverProductionAlertSp(
			string AJob,
			int? ASuffix,
			decimal? AQtyReleased,
			decimal? AQtyComplete,
			string Infobar);
	}
}

