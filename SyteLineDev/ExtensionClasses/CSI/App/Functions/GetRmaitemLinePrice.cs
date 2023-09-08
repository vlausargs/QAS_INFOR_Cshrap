//PROJECT NAME: Data
//CLASS NAME: GetRmaitemLinePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetRmaitemLinePrice : IGetRmaitemLinePrice
	{
		readonly IApplicationDB appDB;
		
		public GetRmaitemLinePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? RmaitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount) GetRmaitemLinePriceSp(
			string RmaNum,
			int? RmaitemRmaLine,
			string RmaitemItem,
			decimal? RmaitemQtyToReturn,
			decimal? RmaitemUnitCredit,
			decimal? RmaitemRestockFeeAmt,
			decimal? RmaitemQtyReceived,
			decimal? RmaitemQtyCredited,
			string RmaitemTaxCode1,
			string RmaitemTaxCode2,
			Guid? RmaitemRowPointer,
			decimal? RmaitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount = null)
		{
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaitemRmaLine = RmaitemRmaLine;
			ItemType _RmaitemItem = RmaitemItem;
			QtyUnitNoNegType _RmaitemQtyToReturn = RmaitemQtyToReturn;
			CostPrcNoNegType _RmaitemUnitCredit = RmaitemUnitCredit;
			AmountType _RmaitemRestockFeeAmt = RmaitemRestockFeeAmt;
			QtyUnitType _RmaitemQtyReceived = RmaitemQtyReceived;
			QtyUnitType _RmaitemQtyCredited = RmaitemQtyCredited;
			TaxCodeType _RmaitemTaxCode1 = RmaitemTaxCode1;
			TaxCodeType _RmaitemTaxCode2 = RmaitemTaxCode2;
			RowPointerType _RmaitemRowPointer = RmaitemRowPointer;
			AmountType _RmaitemLinePrice = RmaitemLinePrice;
			InfobarType _Infobar = Infobar;
			AmtTotType _LineTaxAmount = LineTaxAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRmaitemLinePriceSp";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRmaLine", _RmaitemRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemItem", _RmaitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemQtyToReturn", _RmaitemQtyToReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemUnitCredit", _RmaitemUnitCredit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRestockFeeAmt", _RmaitemRestockFeeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemQtyReceived", _RmaitemQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemQtyCredited", _RmaitemQtyCredited, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemTaxCode1", _RmaitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemTaxCode2", _RmaitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRowPointer", _RmaitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemLinePrice", _RmaitemLinePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineTaxAmount", _LineTaxAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RmaitemLinePrice = _RmaitemLinePrice;
				Infobar = _Infobar;
				LineTaxAmount = _LineTaxAmount;
				
				return (Severity, RmaitemLinePrice, Infobar, LineTaxAmount);
			}
		}
	}
}
