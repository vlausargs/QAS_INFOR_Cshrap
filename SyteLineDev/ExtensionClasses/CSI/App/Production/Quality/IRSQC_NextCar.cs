//PROJECT NAME: Production
//CLASS NAME: IRSQC_NextCar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_NextCar
	{
		(int? ReturnCode,
			string Key,
			string Infobar) RSQC_NextCarSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

