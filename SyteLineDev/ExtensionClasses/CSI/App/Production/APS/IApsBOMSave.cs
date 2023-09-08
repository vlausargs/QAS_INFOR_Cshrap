//PROJECT NAME: Production
//CLASS NAME: IApsBOMSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBOMSave
	{
		int? ApsBOMSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string JSID,
		string MATERIALID,
		string QUANCD,
		decimal? QUANTITY,
		DateTime? EFFDATE,
		DateTime? OBSDATE);
	}
}

