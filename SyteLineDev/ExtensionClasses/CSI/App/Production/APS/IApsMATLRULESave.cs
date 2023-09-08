//PROJECT NAME: Production
//CLASS NAME: IApsMATLRULESave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLRULESave
	{
		int? ApsMATLRULESaveSp(int? InsertFlag,
		int? AltNo,
		string LMATLID,
		string RSITEID,
		string EFFECTID,
		string RMATLID,
		decimal? FLEADTIME,
		decimal? VLEADTIME,
		decimal? TRANSIT,
		int? TIMEOUT,
		decimal? UOMSCALE);
	}
}

