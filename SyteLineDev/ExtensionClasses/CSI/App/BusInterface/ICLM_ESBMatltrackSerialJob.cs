//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBMatltrackSerialJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBMatltrackSerialJob
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBMatltrackSerialJobSp(string RefNum,
		int? RefRelease,
		int? RefLineSuf,
		string Lot,
		string Item);
	}
}

