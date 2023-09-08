//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDrpSetLowLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSDrpSetLowLevel
	{
		int SSSFSDrpSetLowLevelSp(string FormCaption,
		                          int? BgTaskID,
		                          ref string Infobar,
		                          string BGUser);
	}
	
	public class SSSFSDrpSetLowLevel : ISSSFSDrpSetLowLevel
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDrpSetLowLevel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSDrpSetLowLevelSp(string FormCaption,
		                                 int? BgTaskID,
		                                 ref string Infobar,
		                                 string BGUser)
		{
			LongListType _FormCaption = FormCaption;
			GenericNoType _BgTaskID = BgTaskID;
			Infobar _Infobar = Infobar;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDrpSetLowLevelSp";
				
				appDB.AddCommandParameter(cmd, "FormCaption", _FormCaption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
