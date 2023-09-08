//PROJECT NAME: Data
//CLASS NAME: PadjSSD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PadjSSD : IPadjSSD
	{
		readonly IApplicationDB appDB;
		
		public PadjSSD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PadjSSDSp(
			DateTime? PTransDate,
			decimal? PQty,
			decimal? PNetAdjust,
			string PTransNat,
			string PTransNat2,
			decimal? PNewPrice,
			decimal? PCurUCost,
			int? PFixedRate,
			decimal? PExchRate,
			int? PTwoExchRates,
			string PCurrCode,
			string PCustNum,
			string PInvNum,
			int? PInvSeq,
			string PCommCode,
			string PProcessInd,
			string PDelTerm,
			string POrigin,
			string PEcCode,
			string PTransport,
			int? PCurPlaces,
			string Infobar)
		{
			DateType _PTransDate = PTransDate;
			QtyUnitNoNegType _PQty = PQty;
			CostPrcType _PNetAdjust = PNetAdjust;
			TransNatType _PTransNat = PTransNat;
			TransNat2Type _PTransNat2 = PTransNat2;
			AmountType _PNewPrice = PNewPrice;
			CostPrcType _PCurUCost = PCurUCost;
			ListYesNoType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			ListYesNoType _PTwoExchRates = PTwoExchRates;
			CurrCodeType _PCurrCode = PCurrCode;
			CustNumType _PCustNum = PCustNum;
			InvNumType _PInvNum = PInvNum;
			ArInvSeqType _PInvSeq = PInvSeq;
			CommodityCodeType _PCommCode = PCommCode;
			ProcessIndType _PProcessInd = PProcessInd;
			DeltermType _PDelTerm = PDelTerm;
			EcCodeType _POrigin = POrigin;
			EcCodeType _PEcCode = PEcCode;
			TransportType _PTransport = PTransport;
			DecimalPlacesType _PCurPlaces = PCurPlaces;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PadjSSDSp";
				
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNetAdjust", _PNetAdjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPrice", _PNewPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurUCost", _PCurUCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTwoExchRates", _PTwoExchRates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvSeq", _PInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCommCode", _PCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessInd", _PProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDelTerm", _PDelTerm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigin", _POrigin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEcCode", _PEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransport", _PTransport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurPlaces", _PCurPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
