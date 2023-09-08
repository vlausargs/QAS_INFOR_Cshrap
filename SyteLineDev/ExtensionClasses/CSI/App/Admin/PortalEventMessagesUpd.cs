//PROJECT NAME: Admin
//CLASS NAME: PortalEventMessagesUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class PortalEventMessagesUpd : IPortalEventMessagesUpd
	{
		IApplicationDB appDB;
		
		
		public PortalEventMessagesUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PortalEventMessagesUpdSp(Guid? RowPointer,
		DateTime? Username)
		{
			RowPointerType _RowPointer = RowPointer;
			DateType _Username = Username;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalEventMessagesUpdSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
