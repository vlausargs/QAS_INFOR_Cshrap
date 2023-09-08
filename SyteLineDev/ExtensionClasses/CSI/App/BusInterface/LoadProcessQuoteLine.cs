//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadProcessQuoteLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadProcessQuoteLine
	{
		int LoadProcessQuoteLineSp(string pCoNum,
		                           short? pCoLine,
		                           string pConfirmationRef,
		                           string pActionCode,
		                           string pStat,
		                           string pItem,
		                           decimal? pQtyOrderedConv,
		                           string pISOUM,
		                           decimal? pUnitPriceConv,
		                           string pCurrCode,
		                           decimal? pExtPrice,
		                           decimal? pTotPretaxAmt,
		                           string pDesc,
		                           string pReservationRef,
		                           string pFixedPriceItemIndicator,
		                           ref Guid? RowPointer,
		                           ref string Infobar);
	}
	
	public class LoadProcessQuoteLine : ILoadProcessQuoteLine
	{
		readonly IApplicationDB appDB;
		
		public LoadProcessQuoteLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadProcessQuoteLineSp(string pCoNum,
		                                  short? pCoLine,
		                                  string pConfirmationRef,
		                                  string pActionCode,
		                                  string pStat,
		                                  string pItem,
		                                  decimal? pQtyOrderedConv,
		                                  string pISOUM,
		                                  decimal? pUnitPriceConv,
		                                  string pCurrCode,
		                                  decimal? pExtPrice,
		                                  decimal? pTotPretaxAmt,
		                                  string pDesc,
		                                  string pReservationRef,
		                                  string pFixedPriceItemIndicator,
		                                  ref Guid? RowPointer,
		                                  ref string Infobar)
		{
			StringType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			OrderConfirmationRefType _pConfirmationRef = pConfirmationRef;
			StringType _pActionCode = pActionCode;
			StringType _pStat = pStat;
			ItemType _pItem = pItem;
			QtyPerType _pQtyOrderedConv = pQtyOrderedConv;
			UMType _pISOUM = pISOUM;
			CostPrcType _pUnitPriceConv = pUnitPriceConv;
			CurrCodeType _pCurrCode = pCurrCode;
			CostPrcType _pExtPrice = pExtPrice;
			CostPrcType _pTotPretaxAmt = pTotPretaxAmt;
			DescriptionType _pDesc = pDesc;
			OrderLineReservationRefType _pReservationRef = pReservationRef;
			StringType _pFixedPriceItemIndicator = pFixedPriceItemIndicator;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessQuoteLineSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfirmationRef", _pConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActionCode", _pActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyOrderedConv", _pQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pISOUM", _pISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnitPriceConv", _pUnitPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExtPrice", _pExtPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTotPretaxAmt", _pTotPretaxAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDesc", _pDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReservationRef", _pReservationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFixedPriceItemIndicator", _pFixedPriceItemIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
