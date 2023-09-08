//PROJECT NAME: Production
//CLASS NAME: IRSQC_NextMrr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_NextMrr
	{
		(int? ReturnCode,
			string Key,
			string Infobar) RSQC_NextMrrSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

