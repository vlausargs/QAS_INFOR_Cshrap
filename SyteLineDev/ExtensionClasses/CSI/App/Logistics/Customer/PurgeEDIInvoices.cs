//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIInvoices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPurgeEDIInvoices
	{
		(int? ReturnCode, string Message) PurgeEDIInvoicesSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		short? CDateStartingOffset = null,
		short? CDateEndingOffset = null,
		string Message = null);
	}
	
	public class PurgeEDIInvoices : IPurgeEDIInvoices
	{
		readonly IApplicationDB appDB;
		
		public PurgeEDIInvoices(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message) PurgeEDIInvoicesSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		short? CDateStartingOffset = null,
		short? CDateEndingOffset = null,
		string Message = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _CDateStarting = CDateStarting;
			DateType _CDateEnding = CDateEnding;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			InfobarType _Message = Message;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDIInvoicesSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Message", _Message, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Message = _Message;
				
				return (Severity, Message);
			}
		}
	}
}
