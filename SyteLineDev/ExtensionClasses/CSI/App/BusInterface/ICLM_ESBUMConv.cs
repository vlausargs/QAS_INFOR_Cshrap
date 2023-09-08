//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBUMConv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBUMConv
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBUMConvSp(
			string item);
	}
}

