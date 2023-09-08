//PROJECT NAME: Logistics
//CLASS NAME: PurgeInvoiceHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPurgeInvoiceHistory
	{
		(int? ReturnCode, string Infobar) PurgeInvoiceHistorySp(string PInvSource,
		DateTime? PInvDate,
		string PLastInvNum,
		byte? PDeleteLineItemsOnly = (byte)0,
		string Infobar = null,
		short? InvoiceDateOffset = null);
	}
	
	public class PurgeInvoiceHistory : IPurgeInvoiceHistory
	{
		readonly IApplicationDB appDB;
		
		public PurgeInvoiceHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PurgeInvoiceHistorySp(string PInvSource,
		DateTime? PInvDate,
		string PLastInvNum,
		byte? PDeleteLineItemsOnly = (byte)0,
		string Infobar = null,
		short? InvoiceDateOffset = null)
		{
			LongListType _PInvSource = PInvSource;
			CurrentDateType _PInvDate = PInvDate;
			InvNumType _PLastInvNum = PLastInvNum;
			FlagNyType _PDeleteLineItemsOnly = PDeleteLineItemsOnly;
			InfobarType _Infobar = Infobar;
			DateOffsetType _InvoiceDateOffset = InvoiceDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeInvoiceHistorySp";
				
				appDB.AddCommandParameter(cmd, "PInvSource", _PInvSource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastInvNum", _PLastInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDeleteLineItemsOnly", _PDeleteLineItemsOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvoiceDateOffset", _InvoiceDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
