//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIShipSchedules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeEDIShipSchedules : IPurgeEDIShipSchedules
	{
		readonly IApplicationDB appDB;
		
		
		public PurgeEDIShipSchedules(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message) PurgeEDIShipSchedulesSp(string VendorStarting = null,
		string VendorEnding = null,
		string PoStarting = null,
		string PoEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		string Message = null)
		{
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			PoNumType _PoStarting = PoStarting;
			PoNumType _PoEnding = PoEnding;
			DateType _OrderDateStarting = OrderDateStarting;
			DateType _OrderDateEnding = OrderDateEnding;
			DateType _CDateStarting = CDateStarting;
			DateType _CDateEnding = CDateEnding;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
			DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			InfobarType _Message = Message;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDIShipSchedulesSp";
				
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoStarting", _PoStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoEnding", _PoEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
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
