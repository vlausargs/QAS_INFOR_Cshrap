//PROJECT NAME: Data
//CLASS NAME: IUpdWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdWhse
	{
		(int? ReturnCode,
			string Infobar) UpdWhseSp(
			decimal? PDeltaQty,
			string PItem,
			string PWhse,
			string PTrnNum,
			int? PTrnLine,
			string Infobar = null);
	}
}

