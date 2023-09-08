//PROJECT NAME: CSIProjects
//CLASS NAME: ProfileReprintProjPackSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProfileReprintProjPackSlip
	{
		DataTable ProfileReprintProjPackSlipSp(int? StartingSlipNum,
		                                       int? EndingSlipNum);
	}
	
	public class ProfileReprintProjPackSlip : IProfileReprintProjPackSlip
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public ProfileReprintProjPackSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable ProfileReprintProjPackSlipSp(int? StartingSlipNum,
		                                              int? EndingSlipNum)
		{
			PackNumType _StartingSlipNum = StartingSlipNum;
			PackNumType _EndingSlipNum = EndingSlipNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileReprintProjPackSlipSp";
				
				appDB.AddCommandParameter(cmd, "StartingSlipNum", _StartingSlipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSlipNum", _EndingSlipNum, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
