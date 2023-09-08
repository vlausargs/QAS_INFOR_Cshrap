//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBInventoryCountLotSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBInventoryCountLotSerial
	{
		int LoadESBInventoryCountLotSerialSp(string DocumentID,
		                                     string Lot,
		                                     string SerNum,
		                                     int? LineNumber,
		                                     ref string InfoBar);
	}
	
	public class LoadESBInventoryCountLotSerial : ILoadESBInventoryCountLotSerial
	{
		readonly IApplicationDB appDB;
		
		public LoadESBInventoryCountLotSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBInventoryCountLotSerialSp(string DocumentID,
		                                            string Lot,
		                                            string SerNum,
		                                            int? LineNumber,
		                                            ref string InfoBar)
		{
			MarkupElementValueType _DocumentID = DocumentID;
			MarkupElementValueType _Lot = Lot;
			MarkupElementValueType _SerNum = SerNum;
			IntType _LineNumber = LineNumber;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBInventoryCountLotSerialSp";
				
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
