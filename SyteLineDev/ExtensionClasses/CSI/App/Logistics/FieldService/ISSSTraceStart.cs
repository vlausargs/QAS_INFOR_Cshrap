//PROJECT NAME: Logistics
//CLASS NAME: ISSSTraceStart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSTraceStart
	{
		(int? ReturnCode,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar) SSSTraceStartSp(
			long? iMaxTraceSizeMB,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar,
			string FilterDatabaseNameLike,
			string FilterHostNameLike,
			string FilterLoginNameLike,
			string FilterTextDataLike,
			string FilterObjectNameLike,
			int? FilterSPIDEQ);
	}
}

