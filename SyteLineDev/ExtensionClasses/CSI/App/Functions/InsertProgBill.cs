//PROJECT NAME: Data
//CLASS NAME: InsertProgBill.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InsertProgBill : IInsertProgBill
	{
		readonly IApplicationDB appDB;
		
		public InsertProgBill(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) InsertProgBillSp(
			string CoNum,
			int? CoLine,
			string InvoiceFlag,
			DateTime? BillDate,
			string Description,
			decimal? BillAmount,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ProgBillInvoiceFlagType _InvoiceFlag = InvoiceFlag;
			DateType _BillDate = BillDate;
			DescriptionType _Description = Description;
			AmountType _BillAmount = BillAmount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertProgBillSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceFlag", _InvoiceFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillDate", _BillDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillAmount", _BillAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
