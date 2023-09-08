//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSMultiDaySchedulePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSMultiDaySchedulePost
	{
		int SSSFSMultiDaySchedulePostSp(Guid? SessionID,
		                                byte? View,
		                                ref string Infobar);
	}
	
	public class SSSFSMultiDaySchedulePost : ISSSFSMultiDaySchedulePost
	{
		readonly IApplicationDB appDB;
		
		public SSSFSMultiDaySchedulePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSMultiDaySchedulePostSp(Guid? SessionID,
		                                       byte? View,
		                                       ref string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			ListYesNoType _View = View;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSMultiDaySchedulePostSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "View", _View, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
