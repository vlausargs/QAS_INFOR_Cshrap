//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetNumSamples.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetNumSamples
	{
		(int? ReturnCode, int? o_samples) RSQC_GetNumSamplesSp(int? rcvr_num,
		int? o_samples);
	}
}

