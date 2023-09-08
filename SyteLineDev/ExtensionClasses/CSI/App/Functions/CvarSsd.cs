//PROJECT NAME: Data
//CLASS NAME: CvarSsd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CvarSsd : ICvarSsd
	{
		readonly IApplicationDB appDB;
		
		public CvarSsd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CvarSsdSp(
			string VendNum,
			string VendCurrCode,
			Guid? PPoitemRowPointer,
			decimal? PRate,
			int? PVoucher,
			string PTransNat,
			string PTransNat2,
			DateTime? PTransDate,
			decimal? PQty,
			decimal? PNetAdjust,
			decimal? PItemCost,
			string Infobar)
		{
			VendNumType _VendNum = VendNum;
			CurrCodeType _VendCurrCode = VendCurrCode;
			RowPointerType _PPoitemRowPointer = PPoitemRowPointer;
			ExchRateType _PRate = PRate;
			VoucherType _PVoucher = PVoucher;
			TransNatType _PTransNat = PTransNat;
			TransNat2Type _PTransNat2 = PTransNat2;
			DateType _PTransDate = PTransDate;
			QtyUnitType _PQty = PQty;
			AmountType _PNetAdjust = PNetAdjust;
			AmountType _PItemCost = PItemCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CvarSsdSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendCurrCode", _VendCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemRowPointer", _PPoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNetAdjust", _PNetAdjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemCost", _PItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
