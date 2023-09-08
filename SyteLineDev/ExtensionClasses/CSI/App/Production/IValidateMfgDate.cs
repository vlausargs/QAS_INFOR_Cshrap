//PROJECT NAME: Production
//CLASS NAME: IValidateMfgDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateMfgDate
	{
		(int? ReturnCode, DateTime? PStartDateOut,
		DateTime? PEndDateOut,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar) ValidateMfgDateSp(DateTime? PStartDateIn,
		DateTime? PEndDateIn,
		string PItem,
		decimal? PQtyReleased,
		DateTime? PStartDateOut,
		DateTime? PEndDateOut,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar,
		decimal? HrsPerDay = null);
	}
}

