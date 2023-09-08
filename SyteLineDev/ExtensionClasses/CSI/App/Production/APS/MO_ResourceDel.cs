//PROJECT NAME: Production
//CLASS NAME: MO_ResourceDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class MO_ResourceDel : IMO_ResourceDel
	{
		readonly IApplicationDB appDB;
		
		
		public MO_ResourceDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MO_ResourceDelSp(string RESID, int? AltNo)
		{
			ApsResourceType _RESID = RESID;
            ApsAltNoType _AltNo = AltNo;

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ResourceDelSp";
				
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
