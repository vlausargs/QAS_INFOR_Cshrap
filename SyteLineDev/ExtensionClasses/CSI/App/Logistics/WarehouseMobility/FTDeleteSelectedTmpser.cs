//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTDeleteSelectedTmpser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTDeleteSelectedTmpser
	{
		(int? ReturnCode, int? SerCount, string Infobar) FTDeleteSelectedTmpserSp(Guid? SessionID,
		string SerNum,
		int? SerCount,
		string Infobar);
	}
	
	public class FTDeleteSelectedTmpser : IFTDeleteSelectedTmpser
	{
		readonly IApplicationDB appDB;
		
		public FTDeleteSelectedTmpser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SerCount, string Infobar) FTDeleteSelectedTmpserSp(Guid? SessionID,
		string SerNum,
		int? SerCount,
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			SerNumType _SerNum = SerNum;
			IntType _SerCount = SerCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTDeleteSelectedTmpserSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerCount", _SerCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerCount = _SerCount;
				Infobar = _Infobar;
				
				return (Severity, SerCount, Infobar);
			}
		}
	}
}
