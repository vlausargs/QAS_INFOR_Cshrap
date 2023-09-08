//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConfigIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigIns
	{
		(int? ReturnCode, int? comp_id,
		string description,
		DateTime? install_date,
		string item,
		string cust_item,
		string lot,
		int? parent_id,
		string ser_num,
		decimal? qty,
		string reason,
		DateTime? remove_date,
		string revision,
		string u_m,
		string Infobar,
		string charfld1,
		string charfld2,
		string charfld3,
		DateTime? datefld,
		decimal? decifld1,
		decimal? decifld2,
		decimal? decifld3,
		int? logifld) SSSFSUnitConfigInsSp(int? comp_id,
		string description,
		DateTime? install_date,
		string item,
		string cust_item,
		string lot,
		int? parent_id,
		string ser_num,
		decimal? qty,
		string reason,
		DateTime? remove_date,
		string revision,
		string u_m,
		string Infobar,
		string charfld1,
		string charfld2,
		string charfld3,
		DateTime? datefld,
		decimal? decifld1,
		decimal? decifld2,
		decimal? decifld3,
		int? logifld,
		string SroNum = null,
		int? SroLine = null,
		int? SroOper = null,
		int? TransNum = null);
	}
}

