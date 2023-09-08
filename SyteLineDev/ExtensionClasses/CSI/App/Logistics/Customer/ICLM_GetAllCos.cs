//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetAllCos.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetAllCos
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_GetAllCosSp(
			string CoType);
	}
}

