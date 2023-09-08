//PROJECT NAME: Production
//CLASS NAME: IApsEXRCPTSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsEXRCPTSave
	{
		int? ApsEXRCPTSaveSp(int? InsertFlag,
		int? AltNo,
		string ORDERID,
		string MATERIALID,
		DateTime? EXRCPTDATE,
		DateTime? PROJDATE,
		decimal? PROJQTY,
		string MATLDELVID,
		decimal? RESERVEDQTY,
		Guid? SLREF);
	}
}

