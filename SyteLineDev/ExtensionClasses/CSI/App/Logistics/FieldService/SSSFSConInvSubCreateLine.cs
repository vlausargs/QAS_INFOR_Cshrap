//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCreateLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCreateLine : ISSSFSConInvSubCreateLine
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCreateLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string DeferredAcct,
			string DeferredAcctUnit1,
			string DeferredAcctUnit2,
			string DeferredAcctUnit3,
			string DeferredAcctUnit4,
			int? InvLine,
			int? InvSubLine,
			string Infobar) SSSFSConInvSubCreateLineSp(
			string InvNum,
			string SerNum,
			string Item,
			string Description,
			string Contract,
			int? ContLine,
			decimal? Rate,
			DateTime? StartDate,
			DateTime? EndDate,
			string BillFreq,
			DateTime? BilledThru,
			decimal? Qty,
			int? FirstInside,
			decimal? Amount,
			DateTime? BillStart,
			DateTime? BillEnd,
			string TaxCode1,
			string TaxCode2,
			string SalesAcct,
			string SalesAcctUnit1,
			string SalesAcctUnit2,
			string SalesAcctUnit3,
			string SalesAcctUnit4,
			int? CheckAmort,
			string CustNum,
			string ProductCode,
			string Whse,
			string ContPriceBasis,
			decimal? MeterRate,
			int? StartMeterAmt,
			int? EndMeterAmt,
			int? BillingStartMeterAmt,
			int? BillingEndMeterAmt,
			decimal? DateAmount,
			decimal? MeterAmount,
			int? InclWaiverCharge,
			string DeferredAcct,
			string DeferredAcctUnit1,
			string DeferredAcctUnit2,
			string DeferredAcctUnit3,
			string DeferredAcctUnit4,
			int? InvLine,
			int? InvSubLine,
			string Infobar)
		{
			InvNumType _InvNum = InvNum;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			CostPrcType _Rate = Rate;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			FSContBillFreqType _BillFreq = BillFreq;
			DateType _BilledThru = BilledThru;
			QtyUnitType _Qty = Qty;
			ListYesNoType _FirstInside = FirstInside;
			AmountType _Amount = Amount;
			DateType _BillStart = BillStart;
			DateType _BillEnd = BillEnd;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			AcctType _SalesAcct = SalesAcct;
			UnitCode1Type _SalesAcctUnit1 = SalesAcctUnit1;
			UnitCode2Type _SalesAcctUnit2 = SalesAcctUnit2;
			UnitCode3Type _SalesAcctUnit3 = SalesAcctUnit3;
			UnitCode4Type _SalesAcctUnit4 = SalesAcctUnit4;
			ListYesNoType _CheckAmort = CheckAmort;
			CustNumType _CustNum = CustNum;
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			FSContPriceBasisType _ContPriceBasis = ContPriceBasis;
			CostPrcType _MeterRate = MeterRate;
			FSMeterAmtType _StartMeterAmt = StartMeterAmt;
			FSMeterAmtType _EndMeterAmt = EndMeterAmt;
			FSMeterAmtType _BillingStartMeterAmt = BillingStartMeterAmt;
			FSMeterAmtType _BillingEndMeterAmt = BillingEndMeterAmt;
			AmountType _DateAmount = DateAmount;
			AmountType _MeterAmount = MeterAmount;
			ListYesNoType _InclWaiverCharge = InclWaiverCharge;
			AcctType _DeferredAcct = DeferredAcct;
			UnitCode1Type _DeferredAcctUnit1 = DeferredAcctUnit1;
			UnitCode2Type _DeferredAcctUnit2 = DeferredAcctUnit2;
			UnitCode3Type _DeferredAcctUnit3 = DeferredAcctUnit3;
			UnitCode4Type _DeferredAcctUnit4 = DeferredAcctUnit4;
			IntType _InvLine = InvLine;
			IntType _InvSubLine = InvSubLine;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCreateLineSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rate", _Rate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillFreq", _BillFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BilledThru", _BilledThru, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstInside", _FirstInside, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillStart", _BillStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillEnd", _BillEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesAcct", _SalesAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit1", _SalesAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit2", _SalesAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit3", _SalesAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit4", _SalesAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckAmort", _CheckAmort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContPriceBasis", _ContPriceBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MeterRate", _MeterRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartMeterAmt", _StartMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndMeterAmt", _EndMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingStartMeterAmt", _BillingStartMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingEndMeterAmt", _BillingEndMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateAmount", _DateAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MeterAmount", _MeterAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclWaiverCharge", _InclWaiverCharge, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeferredAcct", _DeferredAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeferredAcctUnit1", _DeferredAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeferredAcctUnit2", _DeferredAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeferredAcctUnit3", _DeferredAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeferredAcctUnit4", _DeferredAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvSubLine", _InvSubLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DeferredAcct = _DeferredAcct;
				DeferredAcctUnit1 = _DeferredAcctUnit1;
				DeferredAcctUnit2 = _DeferredAcctUnit2;
				DeferredAcctUnit3 = _DeferredAcctUnit3;
				DeferredAcctUnit4 = _DeferredAcctUnit4;
				InvLine = _InvLine;
				InvSubLine = _InvSubLine;
				Infobar = _Infobar;
				
				return (Severity, DeferredAcct, DeferredAcctUnit1, DeferredAcctUnit2, DeferredAcctUnit3, DeferredAcctUnit4, InvLine, InvSubLine, Infobar);
			}
		}
	}
}
