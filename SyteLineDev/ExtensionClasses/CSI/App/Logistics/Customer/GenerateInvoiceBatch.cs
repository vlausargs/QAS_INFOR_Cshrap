//PROJECT NAME: CSICustomer
//CLASS NAME: GenerateInvoiceBatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGenerateInvoiceBatch
	{
		(int? ReturnCode, string Infobar) GenerateInvoiceBatchSp(DateTime? CloseDate,
		byte? ExcludeInvoicesOnClosingDate = (byte)0,
		byte? OverrideInvBatchCreateRules = (byte)0,
		string Description = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string Infobar = null);
	}
	
	public class GenerateInvoiceBatch : IGenerateInvoiceBatch
	{
		readonly IApplicationDB appDB;
		
		public GenerateInvoiceBatch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenerateInvoiceBatchSp(DateTime? CloseDate,
		byte? ExcludeInvoicesOnClosingDate = (byte)0,
		byte? OverrideInvBatchCreateRules = (byte)0,
		string Description = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string Infobar = null)
		{
			DateType _CloseDate = CloseDate;
			ListYesNoType _ExcludeInvoicesOnClosingDate = ExcludeInvoicesOnClosingDate;
			ListYesNoType _OverrideInvBatchCreateRules = OverrideInvBatchCreateRules;
			DescriptionType _Description = Description;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateInvoiceBatchSp";
				
				appDB.AddCommandParameter(cmd, "CloseDate", _CloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeInvoicesOnClosingDate", _ExcludeInvoicesOnClosingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverrideInvBatchCreateRules", _OverrideInvBatchCreateRules, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
