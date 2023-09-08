//PROJECT NAME: Production
//CLASS NAME: IApsRESRCSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsRESRCSave
	{
		int? ApsRESRCSaveSp(int? InsertFlag,
		int? AltNo,
		string RESID,
		string DESCR,
		string RESTYPE,
		string fa_num,
		int? SEQRL,
		int? SELRL,
		int? TIEREDRL1,
		int? TIEREDRL2,
		int? TIEREDRL3,
		decimal? SELVALUE,
		decimal? SETUPDEL,
		string PARTSETUP,
		string ALLOCCD,
		string INFINITEFG,
		string SUPER,
		string SUMFG,
		string SCHEDFG,
		string FINALQFG,
		string LOADFG,
		string SHIFTID1,
		string SHIFTID2,
		string SHIFTID3,
		string SHIFTID4,
		decimal? MAXORUN,
		string MUSTCOMPFG,
		int? RESIDQTY,
        string plant,
        string RESID_alias);
	}
}

