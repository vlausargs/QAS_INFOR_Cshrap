//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIASN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeEDIASN : IPurgeEDIASN
	{
		readonly IApplicationDB appDB;
		
		
		public PurgeEDIASN(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message) PurgeEDIASNSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
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
				cmd.CommandText = "PurgeEDIASNSp";
				
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
