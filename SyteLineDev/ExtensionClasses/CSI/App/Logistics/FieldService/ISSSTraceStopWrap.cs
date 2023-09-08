//PROJECT NAME: Logistics
//CLASS NAME: ISSSTraceStopWrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSTraceStopWrap
	{
		(int? ReturnCode,
		string Infobar) SSSTraceStopWrapSp(
			int? iTraceID,
			string Infobar);
	}
}

