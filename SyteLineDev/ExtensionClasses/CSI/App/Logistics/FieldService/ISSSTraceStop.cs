//PROJECT NAME: Logistics
//CLASS NAME: ISSSTraceStop.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSTraceStop
	{
		(int? ReturnCode,
			string Infobar) SSSTraceStopSp(
			int? iTraceID,
			string Infobar);
	}
}

