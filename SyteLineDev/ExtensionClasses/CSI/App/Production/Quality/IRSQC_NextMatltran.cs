//PROJECT NAME: Production
//CLASS NAME: IRSQC_NextMatltran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_NextMatltran
	{
		(int? ReturnCode,
			string Key,
			string Infobar) RSQC_NextMatltranSp(
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

