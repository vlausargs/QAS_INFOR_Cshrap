//PROJECT NAME: CSIProjects
//CLASS NAME: MilestoneButtonEnable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IMilestoneButtonEnable
	{
		int MilestoneButtonEnableSp(string WBSNum,
		                            ref byte? EnableButton,
		                            ref byte? EnableEstButton);
	}
	
	public class MilestoneButtonEnable : IMilestoneButtonEnable
	{
		readonly IApplicationDB appDB;
		
		public MilestoneButtonEnable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MilestoneButtonEnableSp(string WBSNum,
		                                   ref byte? EnableButton,
		                                   ref byte? EnableEstButton)
		{
			WbsNumType _WBSNum = WBSNum;
			ListYesNoType _EnableButton = EnableButton;
			ListYesNoType _EnableEstButton = EnableEstButton;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MilestoneButtonEnableSp";
				
				appDB.AddCommandParameter(cmd, "WBSNum", _WBSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EnableButton", _EnableButton, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableEstButton", _EnableEstButton, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EnableButton = _EnableButton;
				EnableEstButton = _EnableEstButton;
				
				return Severity;
			}
		}
	}
}
