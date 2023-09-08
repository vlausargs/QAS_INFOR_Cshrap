//PROJECT NAME: Production
//CLASS NAME: IJobRoutesOEE.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobRoutesOEE
	{
		(int? ReturnCode, decimal? Availability,
		decimal? Performance,
		decimal? Quality,
		decimal? OEE,
		decimal? TotalPieces,
		decimal? GoodPieces,
		decimal? OperatingTime,
		decimal? AvailableProdTime,
		decimal? UnavailableProdTime) JobRoutesOEESp(string ResourceGroup,
		string ResourceId,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		decimal? Availability = null,
		decimal? Performance = null,
		decimal? Quality = null,
		decimal? OEE = null,
		decimal? TotalPieces = null,
		decimal? GoodPieces = null,
		decimal? OperatingTime = null,
		decimal? AvailableProdTime = null,
		decimal? UnavailableProdTime = null);
	}
}

