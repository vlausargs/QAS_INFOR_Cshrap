//PROJECT NAME: Logistics
//CLASS NAME: GenerateTmpShipSeqSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateTmpShipSeqSerial : IGenerateTmpShipSeqSerial
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateTmpShipSeqSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GenerateTmpShipSeqSerialSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		string SerNum,
		string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Select = Select;
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
			SerNumType _SerNum = SerNum;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateTmpShipSeqSerialSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
