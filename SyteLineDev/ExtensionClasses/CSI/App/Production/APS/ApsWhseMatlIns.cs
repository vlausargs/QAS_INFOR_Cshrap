//PROJECT NAME: Production
//CLASS NAME: ApsWhseMatlIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsWhseMatlIns : IApsWhseMatlIns
	{
		readonly IApplicationDB appDB;
		
		
		public ApsWhseMatlIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsWhseMatlInsSp(string MATERIALID,
		string WHSE,
		int? FLAGS,
		decimal? QUONHAND,
		decimal? SAFETYSTOCK,
		int? SRCPRIORITY,
		string SRCCUSTOMER,
		string SRCWORKCENTER,
		int? AltNo)
		{
			ApsMaterialType _MATERIALID = MATERIALID;
			ApsWhseType _WHSE = WHSE;
			ApsBitFlagsType _FLAGS = FLAGS;
			ApsFloatType _QUONHAND = QUONHAND;
			ApsFloatType _SAFETYSTOCK = SAFETYSTOCK;
			ApsSmallIntType _SRCPRIORITY = SRCPRIORITY;
			ApsCustomerType _SRCCUSTOMER = SRCCUSTOMER;
			ApsWorkCenterType _SRCWORKCENTER = SRCWORKCENTER;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsWhseMatlInsSp";
				
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WHSE", _WHSE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FLAGS", _FLAGS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QUONHAND", _QUONHAND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAFETYSTOCK", _SAFETYSTOCK, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRCPRIORITY", _SRCPRIORITY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRCCUSTOMER", _SRCCUSTOMER, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRCWORKCENTER", _SRCWORKCENTER, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
