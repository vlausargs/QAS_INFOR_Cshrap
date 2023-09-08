//PROJECT NAME: Finance
//CLASS NAME: TaxBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TaxBase : ITaxBase
	{
		readonly IApplicationDB appDB;
		
		public TaxBase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string DomCurrCode = null)
		{
			DefaultCharType _PInvType = PInvType;
			DefaultCharType _PType = PType;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			AmountType _PAmount = PAmount;
			AmountType _PAmountToApply = PAmountToApply;
			AmountType _PUndiscAmount = PUndiscAmount;
			AmountType _PUWsPrice = PUWsPrice;
			DefaultCharType _PTaxablePrice = PTaxablePrice;
			QtyUnitType _PQtyInvoiced = PQtyInvoiced;
			CurrCodeType _PCurrCode = PCurrCode;
			GenericDate _PInvDate = PInvDate;
			ExchRateType _PExchRate = PExchRate;
			InfobarType _Infobar = Infobar;
			InfobarType _CalledFrom = CalledFrom;
			RowPointerType _tpsProcessId = tpsProcessId;
			RefType _pRefType = pRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			SourceType _pLineRefType = pLineRefType;
			RowPointer _pLinePtr = pLinePtr;
			TaxSystemsType _TPNmbrOfSystems = TPNmbrOfSystems;
			ListYesNoType _EXTGEN_TaxBaseSp_Exists = EXTGEN_TaxBaseSp_Exists;
			ListYesNoType _IsTaxInterfaceAvailable = IsTaxInterfaceAvailable;
			ListYesNoType _vrtx_parm_Exists = vrtx_parm_Exists;
			TaxCodeType _RmaTaxCode1 = RmaTaxCode1;
			TaxCodeType _RmaTaxCode2 = RmaTaxCode2;
			AmountType _RestockFee = RestockFee;
			FlagNyType _CoShipmentApprovalRequired = CoShipmentApprovalRequired;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxBaseSp";
				
				appDB.AddCommandParameter(cmd, "PInvType", _PInvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmountToApply", _PAmountToApply, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUndiscAmount", _PUndiscAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUWsPrice", _PUWsPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxablePrice", _PTaxablePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyInvoiced", _PQtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tpsProcessId", _tpsProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineRefType", _pLineRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLinePtr", _pLinePtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPNmbrOfSystems", _TPNmbrOfSystems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EXTGEN_TaxBaseSp_Exists", _EXTGEN_TaxBaseSp_Exists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsTaxInterfaceAvailable", _IsTaxInterfaceAvailable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vrtx_parm_Exists", _vrtx_parm_Exists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaTaxCode1", _RmaTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaTaxCode2", _RmaTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RestockFee", _RestockFee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipmentApprovalRequired", _CoShipmentApprovalRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
