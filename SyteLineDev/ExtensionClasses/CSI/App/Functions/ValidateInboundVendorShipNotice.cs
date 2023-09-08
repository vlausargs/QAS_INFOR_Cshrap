//PROJECT NAME: Data
//CLASS NAME: ValidateInboundVendorShipNotice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateInboundVendorShipNotice : IValidateInboundVendorShipNotice
	{
		readonly IApplicationDB appDB;
		
		public ValidateInboundVendorShipNotice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ValidateInboundVendorShipNoticeSp(
			Guid? vsn_rowpointer,
			Guid? tp_rowpointer,
			string call_FROM)
		{
			RowPointerType _vsn_rowpointer = vsn_rowpointer;
			RowPointerType _tp_rowpointer = tp_rowpointer;
			InfobarType _call_FROM = call_FROM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateInboundVendorShipNoticeSp";
				
				appDB.AddCommandParameter(cmd, "vsn_rowpointer", _vsn_rowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tp_rowpointer", _tp_rowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "call_FROM", _call_FROM, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
