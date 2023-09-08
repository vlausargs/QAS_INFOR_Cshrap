//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoCi2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoCi2
	{
		(int? ReturnCode,
			string Infobar) CpSoCpSoCi2Sp(
			string PCoNum,
			int? PCoLine,
			int? PcoRelease,
			string PStat,
			decimal? PQtyShipped,
			decimal? PQtyReturned,
			decimal? PQtyRsvd,
			decimal? PQtyReady,
			decimal? PQtyPacked,
			int? PPacked,
			DateTime? PShipDate,
			decimal? PQtyInvoiced,
			decimal? PUnitWeight,
			int? PConsNum,
			decimal? PPrice,
			decimal? PPriceConv,
			decimal? PExportValue,
			string PTransNat,
			string PTransNat2,
			string PProcessInd,
			string PDelterm,
			string PCommCode,
			string POrigin,
			string PTaxCode1,
			string PTaxCode2,
			string PEcCode,
			string PTransport,
			decimal? PSupplQtyConvFactor,
			string Infobar);
	}
}

