//PROJECT NAME: Production
//CLASS NAME: ApsPBOMSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPBOMSave : IApsPBOMSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsPBOMSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPBOMSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		string DESCR,
		string EFFECTID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsPbomType _BOMID = BOMID;
			ApsDescriptType _DESCR = DESCR;
			ApsEffectType _EFFECTID = EFFECTID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPBOMSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMID", _BOMID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFFECTID", _EFFECTID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
