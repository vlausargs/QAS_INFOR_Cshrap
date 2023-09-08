//PROJECT NAME: Data
//CLASS NAME: IFormatDcsfcTimeHMSSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatDcsfcTimeHMS
	{
		string FormatDcsfcTimeHMSSp(
			int? TimeSec);
	}
}

