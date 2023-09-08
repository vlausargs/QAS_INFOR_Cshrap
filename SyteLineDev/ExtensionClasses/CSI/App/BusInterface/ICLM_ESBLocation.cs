//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBLocation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBLocation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBLocationSp(string LocationID);
	}
}

