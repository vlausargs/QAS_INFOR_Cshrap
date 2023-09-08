//PROJECT NAME: Production
//CLASS NAME: ApsBATPRODORDSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBATPRODORDSave : IApsBATPRODORDSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsBATPRODORDSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBATPRODORDSaveSp(int? InsertFlag,
		int? AltNo,
		int? BATPRODID,
		string ORDERID,
		string JSID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsBatchNumberType _BATPRODID = BATPRODID;
			ApsOrderType _ORDERID = ORDERID;
			ApsJobstepType _JSID = JSID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsBATPRODORDSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BATPRODID", _BATPRODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ORDERID", _ORDERID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JSID", _JSID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
