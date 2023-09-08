//PROJECT NAME: Logistics
//CLASS NAME: RmaitemLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaitemLog : IRmaitemLog
	{
		readonly IApplicationDB appDB;
		
		public RmaitemLog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RmaitemLogSp(
			string Action,
			decimal? OldQtyToReturnConv,
			decimal? NewQtyToReturnConv,
			decimal? OldUnitCreditConv,
			decimal? NewUnitCreditConv,
			string OldUM,
			string NewUM,
			string RmaitemRmaNum,
			int? RmaitemRmaLine,
			string RmaitemItem,
			string RmaitemCoNum,
			int? RmaitemCoLine,
			int? RmaitemCoRelease,
			decimal? UMConvFactor,
			string CustNum,
			int? CurrencyPlaces,
			string Infobar)
		{
			ShortDescType _Action = Action;
			QtyUnitNoNegType _OldQtyToReturnConv = OldQtyToReturnConv;
			QtyUnitNoNegType _NewQtyToReturnConv = NewQtyToReturnConv;
			CostPrcNoNegType _OldUnitCreditConv = OldUnitCreditConv;
			CostPrcNoNegType _NewUnitCreditConv = NewUnitCreditConv;
			UMType _OldUM = OldUM;
			UMType _NewUM = NewUM;
			RmaNumType _RmaitemRmaNum = RmaitemRmaNum;
			RmaLineType _RmaitemRmaLine = RmaitemRmaLine;
			ItemType _RmaitemItem = RmaitemItem;
			CoNumType _RmaitemCoNum = RmaitemCoNum;
			CoLineType _RmaitemCoLine = RmaitemCoLine;
			CoReleaseType _RmaitemCoRelease = RmaitemCoRelease;
			UMConvFactorType _UMConvFactor = UMConvFactor;
			CustNumType _CustNum = CustNum;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaitemLogSp";
				
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldQtyToReturnConv", _OldQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewQtyToReturnConv", _NewQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUnitCreditConv", _OldUnitCreditConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUnitCreditConv", _NewUnitCreditConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUM", _OldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUM", _NewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRmaNum", _RmaitemRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRmaLine", _RmaitemRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemItem", _RmaitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemCoNum", _RmaitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemCoLine", _RmaitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemCoRelease", _RmaitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UMConvFactor", _UMConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
