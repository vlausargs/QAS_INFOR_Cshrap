//PROJECT NAME: Production
//CLASS NAME: ApsPARTSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPARTSave : IApsPARTSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsPARTSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPARTSaveSp(int? InsertFlag,
		int? AltNo,
		string PARTID,
		string DESCR,
		string FAMILY,
		string PROCPLANID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsPartType _PARTID = PARTID;
			ApsDescriptType _DESCR = DESCR;
			ApsPartType _FAMILY = FAMILY;
			ApsProcplanType _PROCPLANID = PROCPLANID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPARTSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PARTID", _PARTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FAMILY", _FAMILY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROCPLANID", _PROCPLANID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
