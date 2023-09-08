//PROJECT NAME: Data
//CLASS NAME: PrjsSsd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrjsSsd : IPrjsSsd
	{
		readonly IApplicationDB appDB;
		
		public PrjsSsd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjShipSeqType _PSeq = PSeq;
			ProjTransSeqType _PTransSeq = PTransSeq;
			QtyPerType _PQty = PQty;
			CostPrcType _PCost = PCost;
			CurrentDateType _PDate = PDate;
			EcCodeType _PEcCode = PEcCode;
			AmountType _PExportValue = PExportValue;
			CommodityCodeType _PCommCode = PCommCode;
			DeltermType _PDelterm = PDelterm;
			ProcessIndType _PProcessInd = PProcessInd;
			TransNatType _PTransNat = PTransNat;
			TransNat2Type _PTransNat2 = PTransNat2;
			UnitWeightType _PUnitWeight = PUnitWeight;
			UMConvFactorType _PSupplQtyConvFactor = PSupplQtyConvFactor;
			TransportType _PTransport = PTransport;
			EcCodeType _POrigin = POrigin;
			TransIndicatorType _PTransInd = PTransInd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrjsSsdSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransSeq", _PTransSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCost", _PCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEcCode", _PEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExportValue", _PExportValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCommCode", _PCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDelterm", _PDelterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessInd", _PProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitWeight", _PUnitWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSupplQtyConvFactor", _PSupplQtyConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransport", _PTransport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigin", _POrigin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransInd", _PTransInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
