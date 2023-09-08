//PROJECT NAME: CSIMaterial
//CLASS NAME: PrintInvShtsDeleteTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IPrintInvShtsDeleteTT
	{
		int PrintInvShtsDeleteTTSp(Guid? PSessionID);
	}
	
	public class PrintInvShtsDeleteTT : IPrintInvShtsDeleteTT
	{
		readonly IApplicationDB appDB;
		
		public PrintInvShtsDeleteTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PrintInvShtsDeleteTTSp(Guid? PSessionID)
		{
			RowPointer _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInvShtsDeleteTTSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
