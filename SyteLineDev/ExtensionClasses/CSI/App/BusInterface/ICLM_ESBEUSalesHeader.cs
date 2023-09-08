//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBEUSalesHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBEUSalesHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBEUSalesHeaderSp();
	}
}

