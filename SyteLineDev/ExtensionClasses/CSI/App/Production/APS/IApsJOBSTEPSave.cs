//PROJECT NAME: Production
//CLASS NAME: IApsJOBSTEPSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsJOBSTEPSave
	{
		int? ApsJOBSTEPSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string WORKCENTER,
		string JSID,
		string DESCR,
		string STEPEXP,
		int? STEPEXPRL,
		string RESACTN1,
		string RESACTN2,
		string RESACTN3,
		string RESACTN4,
		string RESACTN5,
		string RESACTN6,
		string RESID1,
		string RESID2,
		string RESID3,
		string RESID4,
		string RESID5,
		string RESID6,
		int? RESNMBR1,
		int? RESNMBR2,
		int? RESNMBR3,
		int? RESNMBR4,
		int? RESNMBR5,
		int? RESNMBR6,
		decimal? STEPTIME,
		int? STEPTMRL,
		DateTime? EFFDATE,
		DateTime? OBSDATE,
		string RGID,
		string TABID,
		int? WHENRL,
		string BASEDCD,
		decimal? SETUPTIME,
		string STIMEXP,
		int? STIMEXPRL,
		decimal? MOVETIME,
		decimal? QTIME,
		decimal? COOLTIME,
		int? CRSBRKRL,
		int? OLTYPE,
		decimal? OLVALUE,
		decimal? SPLITSIZE,
		string BATCHDEF,
		int? SPLITRULE,
		string SPLITGROUP);
	}
}

