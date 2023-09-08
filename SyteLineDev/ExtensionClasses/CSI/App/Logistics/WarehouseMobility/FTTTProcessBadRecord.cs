//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTProcessBadRecord.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTTProcessBadRecord
	{
		int FTTTProcessBadRecordSp(Guid? SessionID,
		                           decimal? TransNum,
		                           string ErrorMsg,
		                           ref string Infobar);
	}
	
	public class FTTTProcessBadRecord : IFTTTProcessBadRecord
	{
		readonly IApplicationDB appDB;
		
		public FTTTProcessBadRecord(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTTTProcessBadRecordSp(Guid? SessionID,
		                                  decimal? TransNum,
		                                  string ErrorMsg,
		                                  ref string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			HugeTransNumType _TransNum = TransNum;
			InfobarType _ErrorMsg = ErrorMsg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTTTProcessBadRecordSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
