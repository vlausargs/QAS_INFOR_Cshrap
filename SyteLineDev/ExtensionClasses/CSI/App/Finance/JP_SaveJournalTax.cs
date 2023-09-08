//PROJECT NAME: Finance
//CLASS NAME: JP_SaveJournalTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JP_SaveJournalTax : IJP_SaveJournalTax
	{
		readonly IApplicationDB appDB;
		
		
		public JP_SaveJournalTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JP_SaveJournalTaxSp(int? JPTaxable,
		Guid? RowPointer,
		string JPTaxCode,
		decimal? JPTaxRate,
		decimal? JPTaxAmount,
		int? JPEntryIsTax)
		{
			ListYesNoType _JPTaxable = JPTaxable;
			RowPointerType _RowPointer = RowPointer;
			TaxCodeType _JPTaxCode = JPTaxCode;
			TaxRateType _JPTaxRate = JPTaxRate;
			AmountType _JPTaxAmount = JPTaxAmount;
			ListYesNoType _JPEntryIsTax = JPEntryIsTax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JP_SaveJournalTaxSp";
				
				appDB.AddCommandParameter(cmd, "JPTaxable", _JPTaxable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JPTaxCode", _JPTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JPTaxRate", _JPTaxRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JPTaxAmount", _JPTaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JPEntryIsTax", _JPEntryIsTax, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
