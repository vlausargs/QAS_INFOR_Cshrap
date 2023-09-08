//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBRequisitionHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBRequisitionHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBRequisitionHeaderSp(string ReqNum);
	}
}

