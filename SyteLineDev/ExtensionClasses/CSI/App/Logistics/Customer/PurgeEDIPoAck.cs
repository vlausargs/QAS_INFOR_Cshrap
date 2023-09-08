//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIPoAck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPurgeEDIPoAck
	{
		(int? ReturnCode, string Infobar) PurgeEDIPoAckSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string Posted = null,
		short? CDateStartingOffset = null,
		short? CDateEndingOffset = null,
		string Infobar = null);
	}
	
	public class PurgeEDIPoAck : IPurgeEDIPoAck
	{
		readonly IApplicationDB appDB;
		
		public PurgeEDIPoAck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PurgeEDIPoAckSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string Posted = null,
		short? CDateStartingOffset = null,
		short? CDateEndingOffset = null,
		string Infobar = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _CDateStarting = CDateStarting;
			DateType _CDateEnding = CDateEnding;
			StringType _Posted = Posted;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDIPoAckSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Posted", _Posted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
