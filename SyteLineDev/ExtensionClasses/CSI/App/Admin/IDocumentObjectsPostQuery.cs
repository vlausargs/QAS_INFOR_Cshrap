//PROJECT NAME: Admin
//CLASS NAME: IDocumentObjectsPostQuery.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IDocumentObjectsPostQuery
	{
		(int? ReturnCode, string Revision,
		string Status,
		DateTime? EffectiveStartDate,
		DateTime? EffectiveEndDate,
		int? IsExternal) DocumentObjectsPostQuerySp(Guid? DocumentObjectRowPointer,
		string Revision,
		string Status,
		DateTime? EffectiveStartDate,
		DateTime? EffectiveEndDate,
		int? IsExternal);
	}
}

