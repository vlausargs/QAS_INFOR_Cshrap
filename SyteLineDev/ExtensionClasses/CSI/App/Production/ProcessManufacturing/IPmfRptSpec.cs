//PROJECT NAME: Production
//CLASS NAME: IPmfRptSpec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRptSpec
	{
		(int? ReturnCode,
			string InfoBar,
			Guid? SessionId,
			int? Seq) PmfRptSpecSp(
			string InfoBar = null,
			int? PostProcessing = 0,
			Guid? SessionId = null,
			int? Seq = null,
			int? ClearSession = 0);
	}
}

