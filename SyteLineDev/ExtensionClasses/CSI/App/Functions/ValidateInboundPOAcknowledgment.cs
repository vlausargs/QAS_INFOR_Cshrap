//PROJECT NAME: Data
//CLASS NAME: ValidateInboundPOAcknowledgment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateInboundPOAcknowledgment : IValidateInboundPOAcknowledgment
	{
		readonly IApplicationDB appDB;
		
		public ValidateInboundPOAcknowledgment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ValidateInboundPOAcknowledgmentSp(
			Guid? poack_rowpointer,
			Guid? tp_rowpointer,
			string call_from)
		{
			RowPointerType _poack_rowpointer = poack_rowpointer;
			RowPointerType _tp_rowpointer = tp_rowpointer;
			StringType _call_from = call_from;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateInboundPOAcknowledgmentSp";
				
				appDB.AddCommandParameter(cmd, "poack_rowpointer", _poack_rowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tp_rowpointer", _tp_rowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "call_from", _call_from, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
