//PROJECT NAME: Logistics
//CLASS NAME: IGenerateTmpShipSeqSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateTmpShipSeqSerial
	{
		(int? ReturnCode, string InfoBar) GenerateTmpShipSeqSerialSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		string SerNum,
		string InfoBar);
	}
}

