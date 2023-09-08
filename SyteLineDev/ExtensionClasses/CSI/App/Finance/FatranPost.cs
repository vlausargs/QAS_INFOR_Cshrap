//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IFatranPost
	{
		int FatranPostSp(Guid? ProcessID,
		                 Guid? FatranRowPointer,
		                 ref string Infobar);
	}
	
	public class FatranPost : IFatranPost
	{
		readonly IApplicationDB appDB;
		
		public FatranPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FatranPostSp(Guid? ProcessID,
		                        Guid? FatranRowPointer,
		                        ref string Infobar)
		{
			RowPointerType _ProcessID = ProcessID;
			RowPointerType _FatranRowPointer = FatranRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FatranPostSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FatranRowPointer", _FatranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
