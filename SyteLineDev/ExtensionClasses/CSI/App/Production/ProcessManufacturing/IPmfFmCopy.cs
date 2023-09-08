//PROJECT NAME: Production
//CLASS NAME: IPmfFmCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmCopy
	{
		(int? ReturnCode,
			string InfoBar,
			int? Severity,
			Guid? ToFmRp) PmfFmCopySp(
			string InfoBar = null,
			int? Severity = 0,
			Guid? FromFmRp = null,
			Guid? ToFmRp = null,
			int? ToFmType = null,
			string ToFm = null,
			string ToFmVer = null,
			string OvrdWhse = null,
			int? ToRevision = null,
			int? CopyNotes = 0);
	}
}

