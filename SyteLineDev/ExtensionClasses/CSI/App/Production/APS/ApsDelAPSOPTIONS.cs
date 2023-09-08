//PROJECT NAME: Production
//CLASS NAME: ApsDelAPSOPTIONS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDelAPSOPTIONS : IApsDelAPSOPTIONS
	{
		readonly IApplicationDB appDB;
		
		
		public ApsDelAPSOPTIONS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDelAPSOPTIONSSp(Guid? Rowp,
		int? AltNo)
		{
			RowPointerType _Rowp = Rowp;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsDelAPSOPTIONSSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
