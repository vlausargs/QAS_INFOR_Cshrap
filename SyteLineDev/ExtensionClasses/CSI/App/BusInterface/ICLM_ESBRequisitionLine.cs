//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBRequisitionLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBRequisitionLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBRequisitionLineSp(string ReqNum);
	}
}

