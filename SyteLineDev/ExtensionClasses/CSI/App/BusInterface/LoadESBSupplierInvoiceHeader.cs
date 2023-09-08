//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBSupplierInvoiceHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBSupplierInvoiceHeader : ILoadESBSupplierInvoiceHeader
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBSupplierInvoiceHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBSupplierInvoiceHeaderSp(string ActionExpression = null,
		string SupplierInvoice = null,
		string VendNum = null,
		decimal? PreSubunitRoundedTotalAmount = null,
		decimal? SubunitRoundingAmount = null,
		string SubunitRoundingCurrCode = null,
		DateTime? InvDate = null,
		DateTime? DueDate = null,
		string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			VendInvNumType _SupplierInvoice = SupplierInvoice;
			VendNumType _VendNum = VendNum;
			AmountType _PreSubunitRoundedTotalAmount = PreSubunitRoundedTotalAmount;
			AmountType _SubunitRoundingAmount = SubunitRoundingAmount;
			CurrCodeType _SubunitRoundingCurrCode = SubunitRoundingCurrCode;
			DateType _InvDate = InvDate;
			DateType _DueDate = DueDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBSupplierInvoiceHeaderSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplierInvoice", _SupplierInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreSubunitRoundedTotalAmount", _PreSubunitRoundedTotalAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubunitRoundingAmount", _SubunitRoundingAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubunitRoundingCurrCode", _SubunitRoundingCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
