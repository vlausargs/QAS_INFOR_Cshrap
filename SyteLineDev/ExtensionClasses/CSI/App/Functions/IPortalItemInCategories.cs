//PROJECT NAME: Data
//CLASS NAME: IPortalItemInCategories.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalItemInCategories
	{
		int? PortalItemInCategoriesFn(
			Guid? rp,
			string item);
	}
}

