//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSerialsTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSerialsTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSerialsTransSp(decimal? TransNum,
		string Lot = null);
	}
}

