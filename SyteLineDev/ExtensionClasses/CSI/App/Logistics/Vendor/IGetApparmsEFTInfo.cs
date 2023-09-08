//PROJECT NAME: Logistics
//CLASS NAME: IGetApparmsEFTInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetApparmsEFTInfo
	{
		(int? ReturnCode, string PEFTFormat,
		string PEFTDestinationID,
		string PEFTOriginationID,
		decimal? PEFTCompanyID) GetApparmsEFTInfoSp(string PEFTFormat,
		string PEFTDestinationID,
		string PEFTOriginationID,
		decimal? PEFTCompanyID);
	}
}

