//PROJECT NAME: BusInterface
//CLASS NAME: IGenerateReceiveShipBODPL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IGenerateReceiveShipBODPL
	{
		(int? ReturnCode, string Infobar) GenerateReceiveShipBODPLSp(string RefNum,
		string ReceivedDateTime,
		string RefType,
		string Infobar = null,
		decimal? ShipmentID = null,
		string Action = null);
	}
}

