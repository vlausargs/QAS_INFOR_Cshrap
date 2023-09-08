//PROJECT NAME: Production
//CLASS NAME: ApsBOMSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBOMSave : IApsBOMSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsBOMSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBOMSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string JSID,
		string MATERIALID,
		string QUANCD,
		decimal? QUANTITY,
		DateTime? EFFDATE,
		DateTime? OBSDATE)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsProcplanType _PROCPLANID = PROCPLANID;
			ApsJobstepType _JSID = JSID;
			ApsMaterialType _MATERIALID = MATERIALID;
			ApsBomQuanCodeType _QUANCD = QUANCD;
			ApsFloatType _QUANTITY = QUANTITY;
			DateTimeType _EFFDATE = EFFDATE;
			DateTimeType _OBSDATE = OBSDATE;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsBOMSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROCPLANID", _PROCPLANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JSID", _JSID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QUANCD", _QUANCD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QUANTITY", _QUANTITY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFFDATE", _EFFDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OBSDATE", _OBSDATE, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
