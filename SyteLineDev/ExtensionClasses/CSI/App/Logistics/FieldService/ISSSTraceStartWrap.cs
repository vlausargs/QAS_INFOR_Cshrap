//PROJECT NAME: Logistics
//CLASS NAME: ISSSTraceStartWrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSTraceStartWrap
	{
		(int? ReturnCode,
		int? oTraceID,
		string oServerName,
		string oTraceFile,
		string Infobar) SSSTraceStartWrapSp(
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

