//PROJECT NAME: Production
//CLASS NAME: ApsBATPRODSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBATPRODSave : IApsBATPRODSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsBATPRODSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBATPRODSaveSp(int? InsertFlag,
		int? AltNo,
		int? BATPRODID,
		string BATDEFID,
		DateTime? BATCHDATE,
		string PROCPLANID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsBatchNumberType _BATPRODID = BATPRODID;
			ApsBatchType _BATDEFID = BATDEFID;
			DateType _BATCHDATE = BATCHDATE;
			ApsProcplanType _PROCPLANID = PROCPLANID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsBATPRODSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BATPRODID", _BATPRODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BATDEFID", _BATDEFID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BATCHDATE", _BATCHDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROCPLANID", _PROCPLANID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
