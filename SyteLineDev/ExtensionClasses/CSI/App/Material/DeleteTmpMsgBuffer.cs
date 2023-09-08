//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteTmpMsgBuffer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IDeleteTmpMsgBuffer
	{
		int DeleteTmpMsgBufferSp(Guid? PSessionID);
	}
	
	public class DeleteTmpMsgBuffer : IDeleteTmpMsgBuffer
	{
		readonly IApplicationDB appDB;
		
		public DeleteTmpMsgBuffer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DeleteTmpMsgBufferSp(Guid? PSessionID)
		{
			RowPointerType _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTmpMsgBufferSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
