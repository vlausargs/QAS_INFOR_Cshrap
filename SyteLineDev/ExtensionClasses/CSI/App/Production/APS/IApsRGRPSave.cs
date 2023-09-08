//PROJECT NAME: Production
//CLASS NAME: IApsRGRPSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsRGRPSave
	{
		int? ApsRGRPSaveSp(int? InsertFlag,
		int? AltNo,
		string RGID,
		string DESCR,
		string SLTYPE,
		decimal? BUFFERIN,
		decimal? BUFFEROUT,
		decimal? INFCAP,
		int? ALLOCRL,
		string INFINITEFG,
		string REALLOCFG,
		string LOADFG,
		string SUMFG,
        string plant,
        string RGID_alias);
	}
}

