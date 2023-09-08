//PROJECT NAME: Production
//CLASS NAME: IRSQC_CanClosePhase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CanClosePhase
	{
		(int? ReturnCode, string can_close) RSQC_CanClosePhaseSp(string flow_num,
		int? i_seq,
		string can_close);
	}
}

