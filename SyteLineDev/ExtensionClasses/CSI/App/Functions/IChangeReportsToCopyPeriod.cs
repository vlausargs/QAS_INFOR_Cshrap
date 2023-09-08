//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToCopyPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToCopyPeriod
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToCopyPeriodSp(
			int? Parm1Value,
			int? Parm2Value,
			int? Parm3Value,
			DateTime? Parm4Value,
			DateTime? Parm5Value,
			DateTime? Parm6Value,
			DateTime? Parm7Value,
			DateTime? Parm8Value,
			DateTime? Parm9Value,
			DateTime? Parm10Value,
			DateTime? Parm11Value,
			DateTime? Parm12Value,
			DateTime? Parm13Value,
			DateTime? Parm14Value,
			DateTime? Parm15Value,
			DateTime? Parm16Value,
			DateTime? Parm17Value,
			DateTime? Parm18Value,
			DateTime? Parm19Value,
			DateTime? Parm20Value,
			DateTime? Parm21Value,
			DateTime? Parm22Value,
			DateTime? Parm23Value,
			DateTime? Parm24Value,
			DateTime? Parm25Value,
			DateTime? Parm26Value,
			DateTime? Parm27Value,
			DateTime? Parm28Value,
			DateTime? Parm29Value,
			string Parm30Value,
			string Parm31Value,
			string Parm32Value,
			string Parm33Value,
			string Parm34Value,
			string Parm35Value,
			string Parm36Value,
			string Parm37Value,
			string Parm38Value,
			string Parm39Value,
			string Parm40Value,
			string Parm41Value,
			string Parm42Value,
			string Infobar);
	}
}

