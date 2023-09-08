//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyOneTransLineMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroCopyOneTransLineMatl : ISSSFSSroCopyOneTransLineMatl
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyOneTransLineMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			Guid? TargetRowPointer) SSSFSSroCopyOneTransLineMatlSp(
			string ToSroNum,
			int? ToSroLine,
			string CustNum,
			string CurrCode,
			int? UseSroWhse,
			decimal? LineQty,
			Guid? OrigRowPointer,
			string BillCode,
			decimal? Cost,
			decimal? CostConv,
			string Loc,
			string Lot,
			string PartnerId,
			decimal? Price,
			decimal? PriceConv,
			string PriceCode,
			string Item,
			string Description,
			decimal? Qty,
			decimal? QtyConv,
			string UM,
			string Whse,
			string TransType,
			int? RtnToStock,
			int? NoteExists,
			string iDefTaxCode1,
			string iDefTaxCode2,
			string iDefBillCode,
			string iDept,
			decimal? iDisc,
			string iTaxCode1,
			string iTaxCode2,
			string iUsageType,
			decimal? iMatlCostConv,
			decimal? iLbrCostConv,
			decimal? iFovhdCostConv,
			decimal? iVovhdCostConv,
			decimal? iOutCostConv,
			string Infobar,
			Guid? TargetRowPointer,
			int? Level = 0,
			DateTime? iPostDate = null,
			DateTime? iTransDate = null,
			DateTime? iExchDate = null)
		{
			FSSRONumType _ToSroNum = ToSroNum;
			FSSROLineType _ToSroLine = ToSroLine;
			CustNumType _CustNum = CustNum;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _UseSroWhse = UseSroWhse;
			QtyUnitType _LineQty = LineQty;
			RowPointerType _OrigRowPointer = OrigRowPointer;
			FSSROBillCodeType _BillCode = BillCode;
			CostPrcType _Cost = Cost;
			CostPrcType _CostConv = CostConv;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			FSPartnerType _PartnerId = PartnerId;
			CostPrcType _Price = Price;
			CostPrcType _PriceConv = PriceConv;
			PriceCodeType _PriceCode = PriceCode;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			QtyUnitType _Qty = Qty;
			QtyUnitType _QtyConv = QtyConv;
			UMType _UM = UM;
			WhseType _Whse = Whse;
			FSSROTransTypeType _TransType = TransType;
			ListYesNoType _RtnToStock = RtnToStock;
			ListYesNoType _NoteExists = NoteExists;
			TaxCodeType _iDefTaxCode1 = iDefTaxCode1;
			TaxCodeType _iDefTaxCode2 = iDefTaxCode2;
			FSSROBillCodeType _iDefBillCode = iDefBillCode;
			DeptType _iDept = iDept;
			LineDiscType _iDisc = iDisc;
			TaxCodeType _iTaxCode1 = iTaxCode1;
			TaxCodeType _iTaxCode2 = iTaxCode2;
			FSSROMatlUsageTypeType _iUsageType = iUsageType;
			CostPrcType _iMatlCostConv = iMatlCostConv;
			CostPrcType _iLbrCostConv = iLbrCostConv;
			CostPrcType _iFovhdCostConv = iFovhdCostConv;
			CostPrcType _iVovhdCostConv = iVovhdCostConv;
			CostPrcType _iOutCostConv = iOutCostConv;
			InfobarType _Infobar = Infobar;
			RowPointerType _TargetRowPointer = TargetRowPointer;
			IntType _Level = Level;
			DateType _iPostDate = iPostDate;
			DateType _iTransDate = iTransDate;
			DateType _iExchDate = iExchDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyOneTransLineMatlSp";
				
				appDB.AddCommandParameter(cmd, "ToSroNum", _ToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSroLine", _ToSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseSroWhse", _UseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineQty", _LineQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigRowPointer", _OrigRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RtnToStock", _RtnToStock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteExists", _NoteExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDefTaxCode1", _iDefTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDefTaxCode2", _iDefTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDefBillCode", _iDefBillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDept", _iDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDisc", _iDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTaxCode1", _iTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTaxCode2", _iTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUsageType", _iUsageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatlCostConv", _iMatlCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLbrCostConv", _iLbrCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFovhdCostConv", _iFovhdCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iVovhdCostConv", _iVovhdCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOutCostConv", _iOutCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TargetRowPointer", _TargetRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPostDate", _iPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iExchDate", _iExchDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				TargetRowPointer = _TargetRowPointer;
				
				return (Severity, Infobar, TargetRowPointer);
			}
		}
	}
}
