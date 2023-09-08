//PROJECT NAME: Admin
//CLASS NAME: IBI_Create_Union_View.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IBI_Create_Union_View
	{
		int? BI_Create_Union_ViewSp(
			string SourceViewName = null,
			string SiteColumnName = null,
			string TargetViewName = null);
	}
}

