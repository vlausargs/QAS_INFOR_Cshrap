//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBMatlTrackLotJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBMatlTrackLotJob
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBMatlTrackLotJobSp(string RefNum,
		int? RefRelease,
		int? RefLineSuf,
		string Item);
	}
}

