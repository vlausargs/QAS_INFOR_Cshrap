//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetSupParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetSupParms
	{
		(int? ReturnCode,
			int? NeedsQC) RSQC_GetSupParmsSp(
			int? NeedsQC);
	}
}

