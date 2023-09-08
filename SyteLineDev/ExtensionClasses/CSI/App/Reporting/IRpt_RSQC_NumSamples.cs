//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_NumSamples.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_NumSamples
	{
		int? Rpt_RSQC_NumSamplesSp(
			int? numsamples = null);
	}
}

