//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipmentLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBShipmentLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipmentLineSp(string RefType,
		string DocumentID);
	}
}

