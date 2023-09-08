//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoCi2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoCi2 : ICpSoCpSoCi2
	{
		readonly IApplicationDB appDB;
		
		public CpSoCpSoCi2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PcoRelease = PcoRelease;
			CoitemStatusType _PStat = PStat;
			QtyUnitNoNegType _PQtyShipped = PQtyShipped;
			QtyUnitNoNegType _PQtyReturned = PQtyReturned;
			QtyUnitType _PQtyRsvd = PQtyRsvd;
			QtyUnitNoNegType _PQtyReady = PQtyReady;
			QtyUnitNoNegType _PQtyPacked = PQtyPacked;
			ListYesNoType _PPacked = PPacked;
			DateType _PShipDate = PShipDate;
			QtyUnitNoNegType _PQtyInvoiced = PQtyInvoiced;
			UnitWeightType _PUnitWeight = PUnitWeight;
			ConsignmentsType _PConsNum = PConsNum;
			CostPrcType _PPrice = PPrice;
			CostPrcType _PPriceConv = PPriceConv;
			AmountType _PExportValue = PExportValue;
			TransNatType _PTransNat = PTransNat;
			TransNat2Type _PTransNat2 = PTransNat2;
			ProcessIndType _PProcessInd = PProcessInd;
			DeltermType _PDelterm = PDelterm;
			CommodityCodeType _PCommCode = PCommCode;
			EcCodeType _POrigin = POrigin;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			EcCodeType _PEcCode = PEcCode;
			TransportType _PTransport = PTransport;
			UMConvFactorType _PSupplQtyConvFactor = PSupplQtyConvFactor;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoCi2Sp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PcoRelease", _PcoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyShipped", _PQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReturned", _PQtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyRsvd", _PQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReady", _PQtyReady, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyPacked", _PQtyPacked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPacked", _PPacked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipDate", _PShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyInvoiced", _PQtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitWeight", _PUnitWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PConsNum", _PConsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrice", _PPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPriceConv", _PPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExportValue", _PExportValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessInd", _PProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDelterm", _PDelterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCommCode", _PCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigin", _POrigin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEcCode", _PEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransport", _PTransport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSupplQtyConvFactor", _PSupplQtyConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
