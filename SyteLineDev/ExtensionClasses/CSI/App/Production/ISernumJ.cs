//PROJECT NAME: Production
//CLASS NAME: ISernumJ.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISernumJ
	{
		(int? ReturnCode,
			decimal? PQtySelected,
			string Infobar) SernumJSp(
			string PWhse,
			string PActionCode,
			decimal? PTransNum,
			string PLoc,
			string PLot,
			decimal? PQty,
			string Workkey,
			decimal? PQtySelected,
			string Infobar,
			string PImportDocId = null,
			string ContainerNum = null);
	}
}

