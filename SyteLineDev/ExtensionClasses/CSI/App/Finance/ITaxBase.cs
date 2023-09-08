//PROJECT NAME: Finance
//CLASS NAME: ITaxBase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITaxBase
	{
		(int? ReturnCode,
			string Infobar) TaxBaseSp(
			string PInvType,
			string PType,
			string PTaxCode1,
			string PTaxCode2,
			decimal? PAmount,
			decimal? PAmountToApply,
			decimal? PUndiscAmount,
			decimal? PUWsPrice,
			string PTaxablePrice,
			decimal? PQtyInvoiced,
			string PCurrCode,
			DateTime? PInvDate,
			decimal? PExchRate,
			string Infobar,
			string CalledFrom = null,
			Guid? tpsProcessId = null,
			string pRefType = null,
			Guid? pHdrPtr = null,
			string pLineRefType = null,
			Guid? pLinePtr = null,
			int? TPNmbrOfSystems = null,
			int? EXTGEN_TaxBaseSp_Exists = null,
			int? IsTaxInterfaceAvailable = null,
			int? vrtx_parm_Exists = null,
			string RmaTaxCode1 = null,
			string RmaTaxCode2 = null,
			decimal? RestockFee = 0,
			int? CoShipmentApprovalRequired = 0,
			string Site = null,
			string DomCurrCode = null);
	}
}

