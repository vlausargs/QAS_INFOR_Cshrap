//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransMiscCstPrcTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransMiscCstPrcTax : ISSSFSSROTransMiscCstPrcTax
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransMiscCstPrcTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DefCost,
		decimal? DefPrice,
		string TaxCode1,
		string TaxCode2,
		string Infobar) SSSFSSROTransMiscCstPrcTaxSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string MiscCode,
		string BillCode,
		DateTime? TransDate,
		string PartnerId,
		decimal? Qty,
		decimal? DefCost,
		decimal? DefPrice,
		string TaxCode1,
		string TaxCode2,
		string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			FSMiscCodeType _MiscCode = MiscCode;
			FSSROBillCodeType _BillCode = BillCode;
			DateType _TransDate = TransDate;
			FSPartnerType _PartnerId = PartnerId;
			QtyUnitType _Qty = Qty;
			CostPrcType _DefCost = DefCost;
			CostPrcType _DefPrice = DefPrice;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransMiscCstPrcTaxSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCode", _MiscCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefCost", _DefCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefPrice", _DefPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DefCost = _DefCost;
				DefPrice = _DefPrice;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				Infobar = _Infobar;
				
				return (Severity, DefCost, DefPrice, TaxCode1, TaxCode2, Infobar);
			}
		}
	}
}
