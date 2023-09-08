//PROJECT NAME: BusInterface
//CLASS NAME: GenerateReceiveShipBODPL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class GenerateReceiveShipBODPL : IGenerateReceiveShipBODPL
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateReceiveShipBODPL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenerateReceiveShipBODPLSp(string RefNum,
		string ReceivedDateTime,
		string RefType,
		string Infobar = null,
		decimal? ShipmentID = null,
		string Action = null)
		{
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			StringType _ReceivedDateTime = ReceivedDateTime;
			StringType _RefType = RefType;
			InfobarType _Infobar = Infobar;
			ShipmentIDType _ShipmentID = ShipmentID;
			StringType _Action = Action;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateReceiveShipBODPLSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivedDateTime", _ReceivedDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
