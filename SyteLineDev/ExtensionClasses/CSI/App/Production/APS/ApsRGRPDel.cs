//PROJECT NAME: Production
//CLASS NAME: ApsRGRPDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsRGRPDel : IApsRGRPDel
	{
		readonly IApplicationDB appDB;
		
		
		public ApsRGRPDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsRGRPDelSp(int? AltNo,
		string RgID)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsResgroupType _RgID = RgID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsRGRPDelSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RgID", _RgID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
