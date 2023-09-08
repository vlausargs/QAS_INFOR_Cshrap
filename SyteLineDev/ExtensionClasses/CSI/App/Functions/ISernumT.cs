//PROJECT NAME: Data
//CLASS NAME: ISernumT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISernumT
	{
		(int? ReturnCode,
			string Infobar) SernumTSp(
			string PType,
			string PWhseType,
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			decimal? PDeltaQty,
			string PTrnNum,
			int? PTrnLine,
			decimal? PTransNum,
			decimal? PRsvdNum,
			string Infobar,
			string PImportDocId);
	}
}

