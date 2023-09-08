//PROJECT NAME: Data
//CLASS NAME: IConvertAmtsToForeign.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertAmtsToForeign
	{
		(int? ReturnCode,
			string Infobar) ConvertAmtsToForeignSp(
			string PPoNum,
			DateTime? PoOrderDate,
			string PCurrCode,
			string OldCurrCode,
			string Infobar);
	}
}

