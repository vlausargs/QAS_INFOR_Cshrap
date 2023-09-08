//PROJECT NAME: Data
//CLASS NAME: IPoitemJobMatlXrefUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoitemJobMatlXrefUpdate
	{
		(int? ReturnCode,
			string Infobar) PoitemJobMatlXrefUpdateSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string Item,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar,
			string Site = null);
	}
}

