//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReceiveShipLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReceiveShipLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceiveShipLineSp(decimal? DocumentID);
	}
}

