//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetRmaparmsLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetRmaparmsLoc
	{
		(int? ReturnCode,
		string Loc,
		int? NeedsQC) RSQC_GetRmaparmsLocSp(
			string Loc,
			int? NeedsQC);
	}
}

