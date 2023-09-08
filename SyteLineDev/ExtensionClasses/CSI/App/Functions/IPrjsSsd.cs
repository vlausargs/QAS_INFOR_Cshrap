//PROJECT NAME: Data
//CLASS NAME: IPrjsSsd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrjsSsd
	{
		(int? ReturnCode,
			string Infobar) PrjsSsdSp(
			string PProjNum,
			int? PTaskNum,
			int? PSeq,
			int? PTransSeq,
			decimal? PQty,
			decimal? PCost,
			DateTime? PDate,
			string PEcCode,
			decimal? PExportValue,
			string PCommCode,
			string PDelterm,
			string PProcessInd,
			string PTransNat,
			string PTransNat2,
			decimal? PUnitWeight,
			decimal? PSupplQtyConvFactor,
			string PTransport,
			string POrigin,
			string PTransInd,
			string Infobar);
	}
}

