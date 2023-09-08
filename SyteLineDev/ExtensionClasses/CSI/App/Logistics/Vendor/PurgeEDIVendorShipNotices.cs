//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIVendorShipNotices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PurgeEDIVendorShipNotices : IPurgeEDIVendorShipNotices
	{
		readonly IApplicationDB appDB;
		
		
		public PurgeEDIVendorShipNotices(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message) PurgeEDIVendorShipNoticesSp(string VendorStarting = null,
		string VendorEnding = null,
		string GRNStarting = null,
		string GRNEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		string Message = null)
		{
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			GrnNumType _GRNStarting = GRNStarting;
			GrnNumType _GRNEnding = GRNEnding;
			DateType _CDateStarting = CDateStarting;
			DateType _CDateEnding = CDateEnding;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			InfobarType _Message = Message;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDIVendorShipNoticesSp";
				
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GRNStarting", _GRNStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GRNEnding", _GRNEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
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
