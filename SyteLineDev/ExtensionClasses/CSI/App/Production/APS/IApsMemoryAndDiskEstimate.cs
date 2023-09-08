//PROJECT NAME: Production
//CLASS NAME: IApsMemoryAndDiskEstimate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMemoryAndDiskEstimate
	{
		(int? ReturnCode,
			int? PMemoryUse,
			int? PDiskUse) ApsMemoryAndDiskEstimateSp(
			int? PAltNo,
			int? PMemoryUse,
			int? PDiskUse);
	}
}

