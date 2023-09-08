//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSerialSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		string Lot);
	}
}

