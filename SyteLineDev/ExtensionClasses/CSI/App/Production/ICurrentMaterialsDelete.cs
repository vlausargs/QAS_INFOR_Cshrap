//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsDelete
	{
		(int? ReturnCode,
		string Infobar) CurrentMaterialsDeleteSp(
			string JobType,
			string ItmItem,
			string Infobar);
	}
}

