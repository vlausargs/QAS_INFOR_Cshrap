//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPoVch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPoVch
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPoVchSp(int? Voucher);
	}
}

