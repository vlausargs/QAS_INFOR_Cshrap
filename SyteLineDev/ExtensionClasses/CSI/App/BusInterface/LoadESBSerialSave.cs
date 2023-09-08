//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBSerialSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBSerialSave
	{
		int LoadESBSerialSaveSp(string DocumentID,
		                        string LineNumber,
		                        string SerNum,
		                        ref string InfoBar);
	}
	
	public class LoadESBSerialSave : ILoadESBSerialSave
	{
		readonly IApplicationDB appDB;
		
		public LoadESBSerialSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBSerialSaveSp(string DocumentID,
		                               string LineNumber,
		                               string SerNum,
		                               ref string InfoBar)
		{
			StringType _DocumentID = DocumentID;
			StringType _LineNumber = LineNumber;
			SerNumType _SerNum = SerNum;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBSerialSaveSp";
				
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
