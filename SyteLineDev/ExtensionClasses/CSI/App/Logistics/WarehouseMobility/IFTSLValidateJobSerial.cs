//PROJECT NAME: Logistics
//CLASS NAME: IFTSLValidateJobSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateJobSerial
	{
		(int? ReturnCode,
			string Infobar) FTSLValidateJobSerialSP(
			string Job,
			string RefType,
			string Stat,
			string SerialNum,
			string Infobar);
	}
}

