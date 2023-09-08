//PROJECT NAME: Production
//CLASS NAME: IApsBATCHSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBATCHSave
	{
		int? ApsBATCHSaveSp(int? InsertFlag,
		int? AltNo,
		string BATDEFID,
		string DESCR,
		string ITEM,
		int? SEPRL,
		int? QUANRL,
		decimal? QVALUE,
		decimal? MINQUAN,
		decimal? MAXQUAN,
		string ADDOVFG,
		int? OVERRL,
		decimal? OVTHRESH,
		string PEROVFG,
		decimal? OVCYCLE);
	}
}

