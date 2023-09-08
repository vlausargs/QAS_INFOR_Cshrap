//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBProductionReceiverHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBProductionReceiverHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBProductionReceiverHeaderSp(decimal? TransNum,
		string RecordType);
	}
}

