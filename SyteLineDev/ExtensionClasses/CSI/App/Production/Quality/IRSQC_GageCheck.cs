//PROJECT NAME: Production
//CLASS NAME: IRSQC_GageCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GageCheck
	{
		(int? ReturnCode, int? o_gage_expired,
		string Infobar) RSQC_GageCheckSp(Guid? i_gage,
		int? o_gage_expired,
		string Infobar);
	}
}

