//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitJobBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitJobBuild
	{
		int? SSSFSUnitJobBuildSp(
			string PJob,
			int? PSuf,
			string PSerNum,
			string PItem,
			int? PId,
			DateTime? PInstallDate,
			int? PSubUnit,
			int? PBatchMode,
			int? PUseActual,
			string PCustNum = null,
			int? PCustSeq = null,
			string PUsrNum = null,
			int? PUsrSeq = null);
	}
}

