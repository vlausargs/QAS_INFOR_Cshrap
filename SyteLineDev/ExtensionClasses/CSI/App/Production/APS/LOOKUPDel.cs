//PROJECT NAME: Production
//CLASS NAME: LOOKUPDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class LOOKUPDel : ILOOKUPDel
	{
		readonly IApplicationDB appDB;
		
		
		public LOOKUPDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LOOKUPDelSp(int? AltNo,
		Guid? RowPointer)
		{
			ApsAltNoType _AltNo = AltNo;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LOOKUPDelSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
