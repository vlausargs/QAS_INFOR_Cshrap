//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToCopyChart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToCopyChart
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToCopyChartSp(
			string Parm1Value,
			string Parm2Value,
			string Parm3Value,
			DateTime? Parm4Value,
			DateTime? Parm5Value,
			string Parm6Value,
			string Parm7Value,
			string Parm8Value,
			string Parm9Value,
			string Parm10Value,
			string Parm11Value,
			int? Parm12Value,
			Guid? Parm13Value,
			string pFromSite,
			string Infobar);
	}
}

