//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBLot
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBLotSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item);
	}
}

