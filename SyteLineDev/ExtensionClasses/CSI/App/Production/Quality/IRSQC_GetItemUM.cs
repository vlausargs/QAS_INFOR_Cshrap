//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetItemUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetItemUM
	{
		(int? ReturnCode,
		string NewUM) RSQC_GetItemUMSp(
			int? RcvrNum,
			string NewUM);
	}
}

