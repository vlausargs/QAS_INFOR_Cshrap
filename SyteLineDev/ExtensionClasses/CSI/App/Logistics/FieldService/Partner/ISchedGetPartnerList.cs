//PROJECT NAME: Logistics
//CLASS NAME: ISchedGetPartnerListSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedGetPartnerList
	{
		ICollectionLoadResponse SchedGetPartnerListSp(
			string FilterUsername,
			string FilterName,
			int? FilterType);
	}
}

