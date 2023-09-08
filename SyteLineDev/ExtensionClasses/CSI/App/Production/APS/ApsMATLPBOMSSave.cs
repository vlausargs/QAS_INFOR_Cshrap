//PROJECT NAME: Production
//CLASS NAME: ApsMATLPBOMSSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLPBOMSSave : IApsMATLPBOMSSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMATLPBOMSSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMATLPBOMSSaveSp(int? InsertFlag,
		int? AltNo,
		string PBOMID,
		string MATERIALID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsPbomType _PBOMID = PBOMID;
			ApsMaterialType _MATERIALID = MATERIALID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMATLPBOMSSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBOMID", _PBOMID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
