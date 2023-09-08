//PROJECT NAME: Data
//CLASS NAME: IDimAttributesUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDimAttributesUpdate
	{
		int? DimAttributesUpdateSp(
			string ObjectName,
			Guid? TableRowPointer,
			string Dimension,
			string AccountStarting,
			string AccountEnding,
			int? UpdateAnalysisAttributes = 1,
			string FilterString = null,
			int? CommitSize = null,
			int? Debug = null,
			int? TaskID = null);
	}
}

