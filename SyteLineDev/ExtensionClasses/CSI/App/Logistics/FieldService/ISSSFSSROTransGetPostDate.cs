//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransGetPostDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROTransGetPostDate
	{
		(int? ReturnCode,
			DateTime? TransDate,
			DateTime? PostDate,
			string Infobar) SSSFSSROTransGetPostDateSp(
			DateTime? TransDate,
			DateTime? PostDate,
			string Infobar);
	}
}

