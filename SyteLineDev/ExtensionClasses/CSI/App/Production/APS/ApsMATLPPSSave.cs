//PROJECT NAME: Production
//CLASS NAME: ApsMATLPPSSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLPPSSave : IApsMATLPPSSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMATLPPSSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMATLPPSSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string MATERIALID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsProcplanType _PROCPLANID = PROCPLANID;
			ApsMaterialType _MATERIALID = MATERIALID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMATLPPSSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROCPLANID", _PROCPLANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
