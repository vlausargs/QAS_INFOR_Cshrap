//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateJobSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateJobSerial : IFTSLValidateJobSerial
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateJobSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FTSLValidateJobSerialSP(
			string Job,
			string RefType,
			string Stat,
			string SerialNum,
			string Infobar)
		{
			JobType _Job = Job;
			StringType _RefType = RefType;
			StringType _Stat = Stat;
			SerNumType _SerialNum = SerialNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateJobSerialSP";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialNum", _SerialNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
