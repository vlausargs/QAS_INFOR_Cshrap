//PROJECT NAME: Production
//CLASS NAME: ApsWhseDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsWhseDel : IApsWhseDel
	{
		readonly IApplicationDB appDB;
		
		
		public ApsWhseDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsWhseDelSp(Guid? Rowp,
		int? AltNo)
		{
			RowPointerType _Rowp = Rowp;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsWhseDelSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
