//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContLineGetItemRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContLineGetItemRate
	{
		(int? ReturnCode, decimal? Rate,
		decimal? MeterRate,
		int? MeterAllow,
		decimal? ProrateRate,
		DateTime? DueDate,
		DateTime? MinBillThru,
		string ProrateUnitOfRate,
		string Infobar) SSSFSContLineGetItemRateSp(string Contract,
		string Item,
		string UnitOfRate,
		DateTime? StartDate = null,
		decimal? Rate = null,
		decimal? MeterRate = null,
		int? MeterAllow = null,
		decimal? ProrateRate = null,
		DateTime? DueDate = null,
		DateTime? MinBillThru = null,
		string ProrateUnitOfRate = null,
		string Infobar = null);
	}
}

