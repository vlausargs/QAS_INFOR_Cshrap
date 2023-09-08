//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBMatltrackSerials.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBMatltrackSerials
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBMatltrackSerialsSP(string RefNum,
		int? RefRelease,
		int? RefLineSuf,
		int? DateSeq,
		DateTime? TransDate);
	}
}

