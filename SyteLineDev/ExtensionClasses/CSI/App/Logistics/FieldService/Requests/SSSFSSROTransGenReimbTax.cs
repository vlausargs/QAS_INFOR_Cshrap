//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransGenReimbTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransGenReimbTax
	{
		(int? ReturnCode, string InfoBar) SSSFSSROTransGenReimbTaxSp(Guid? RowPointer,
		string TransType,
		string InfoBar,
		decimal? TaxAmount = null);
	}
	
	public class SSSFSSROTransGenReimbTax : ISSSFSSROTransGenReimbTax
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransGenReimbTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) SSSFSSROTransGenReimbTaxSp(Guid? RowPointer,
		string TransType,
		string InfoBar,
		decimal? TaxAmount = null)
		{
			RowPointerType _RowPointer = RowPointer;
			FSSROTransTypeType _TransType = TransType;
			Infobar _InfoBar = InfoBar;
			AmountType _TaxAmount = TaxAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransGenReimbTaxSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmount", _TaxAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
