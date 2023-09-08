//PROJECT NAME: Production
//CLASS NAME: ApsWhseMatlDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsWhseMatlDel : IApsWhseMatlDel
	{
		readonly IApplicationDB appDB;
		
		
		public ApsWhseMatlDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsWhseMatlDelSp(Guid? Rowp,
		int? AltNo)
		{
			RowPointerType _Rowp = Rowp;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsWhseMatlDelSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
