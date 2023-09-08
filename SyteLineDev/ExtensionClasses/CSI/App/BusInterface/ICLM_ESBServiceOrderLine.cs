//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBServiceOrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBServiceOrderLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBServiceOrderLineSp(string SroNum);
	}
}

