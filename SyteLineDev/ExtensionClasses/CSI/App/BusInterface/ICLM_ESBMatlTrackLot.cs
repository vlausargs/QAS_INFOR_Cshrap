//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBMatlTrackLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBMatlTrackLot
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBMatlTrackLotSP(string RefNum,
		int? RefRelease,
		int? RefLineSuf,
		int? DateSeq,
		DateTime? TransDate);
	}
}

