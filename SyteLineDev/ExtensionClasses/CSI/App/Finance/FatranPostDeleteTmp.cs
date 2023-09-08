//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostDeleteTmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IFatranPostDeleteTmp
	{
		int FatranPostDeleteTmpSp(Guid? ProcessID);
	}
	
	public class FatranPostDeleteTmp : IFatranPostDeleteTmp
	{
		readonly IApplicationDB appDB;
		
		public FatranPostDeleteTmp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FatranPostDeleteTmpSp(Guid? ProcessID)
		{
			RowPointerType _ProcessID = ProcessID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FatranPostDeleteTmpSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
