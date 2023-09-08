//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListCo14sR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListCo14sR
	{
		int? GenerateOrderPickListCo14sRSp(
			Guid? PSessionID);
	}
}

