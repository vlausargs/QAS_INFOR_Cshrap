//PROJECT NAME: Production
//CLASS NAME: IRSQC_NextTrr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_NextTrr
	{
		(int? ReturnCode,
			string Key,
			string Infobar) RSQC_NextTrrSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

