//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateMrr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateMrr
	{
		(int? ReturnCode,
			string Infobar) RSQC_ValidateMrrSp(
			int? RcvrNum,
			string Infobar);
	}
}

