//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBMatltrackSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBMatltrackSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBMatltrackSerialSp(string RefType,
		string RefNum,
		int? RefRelease,
		int? RefLineSuf,
		string Lot);
	}
}

