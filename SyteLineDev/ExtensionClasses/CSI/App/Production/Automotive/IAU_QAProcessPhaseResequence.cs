//PROJECT NAME: Production
//CLASS NAME: IAU_QAProcessPhaseResequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Automotive
{
	public interface IAU_QAProcessPhaseResequence
	{
		int? AU_QAProcessPhaseResequenceSp(
			string QAProcess);
	}
}

