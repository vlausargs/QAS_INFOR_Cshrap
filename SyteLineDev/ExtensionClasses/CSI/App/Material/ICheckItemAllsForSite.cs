//PROJECT NAME: Material
//CLASS NAME: ICheckItemAllsForSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckItemAllsForSite
	{
		(int? ReturnCode,
		string Infobar) CheckItemAllsForSiteSp(
			string Site,
			string SupplySite,
			string Item,
			string Infobar);
	}
}

