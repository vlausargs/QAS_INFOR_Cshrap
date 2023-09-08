//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBTransferHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBTransferHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBTransferHeaderSp(string DocumentID);
	}
}

