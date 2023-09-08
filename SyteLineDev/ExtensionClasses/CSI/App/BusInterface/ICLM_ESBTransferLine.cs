//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBTransferLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBTransferLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBTransferLineSp(string DocumentID);
	}
}

