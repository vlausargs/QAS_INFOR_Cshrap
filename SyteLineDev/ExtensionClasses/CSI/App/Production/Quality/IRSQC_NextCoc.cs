//PROJECT NAME: Production
//CLASS NAME: IRSQC_NextCoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_NextCoc
	{
		(int? ReturnCode,
			string Key,
			string Infobar) RSQC_NextCocSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

