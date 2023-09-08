//PROJECT NAME: BusInterface
//CLASS NAME: SupplyWEBInPoAck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class SupplyWEBInPoAck : ISupplyWEBInPoAck
	{
		readonly IApplicationDB appDB;
		
		
		public SupplyWEBInPoAck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SupplyWEBInPoAckSp(Guid? TmpAckPoRowPointer,
		string FromLogicalID,
		string FromReferenceID,
		DateTime? FromCreateTime,
		string FromBODID,
		string Infobar)
		{
			RowPointerType _TmpAckPoRowPointer = TmpAckPoRowPointer;
			MessageBusIdType _FromLogicalID = FromLogicalID;
			MessageBusIdType _FromReferenceID = FromReferenceID;
			DateTimeType _FromCreateTime = FromCreateTime;
			MessageBusIdType _FromBODID = FromBODID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SupplyWEBInPoAckSp";
				
				appDB.AddCommandParameter(cmd, "TmpAckPoRowPointer", _TmpAckPoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLogicalID", _FromLogicalID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromReferenceID", _FromReferenceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCreateTime", _FromCreateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromBODID", _FromBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
