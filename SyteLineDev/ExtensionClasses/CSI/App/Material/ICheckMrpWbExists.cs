//PROJECT NAME: Material
//CLASS NAME: ICheckMrpWbExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckMrpWbExists
	{
		(int? ReturnCode,
		int? MrpWbExists,
		string Infobar) CheckMrpWbExistsSp(
			string FromItem,
			string ToItem,
			int? MrpWbExists,
			string Infobar);
	}
}

