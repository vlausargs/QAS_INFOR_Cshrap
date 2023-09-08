//PROJECT NAME: Production
//CLASS NAME: ApsEXRCPTSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsEXRCPTSave : IApsEXRCPTSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsEXRCPTSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsEXRCPTSaveSp(int? InsertFlag,
		int? AltNo,
		string ORDERID,
		string MATERIALID,
		DateTime? EXRCPTDATE,
		DateTime? PROJDATE,
		decimal? PROJQTY,
		string MATLDELVID,
		decimal? RESERVEDQTY,
		Guid? SLREF)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsOrderType _ORDERID = ORDERID;
			ApsMaterialType _MATERIALID = MATERIALID;
			DateTimeType _EXRCPTDATE = EXRCPTDATE;
			DateTimeType _PROJDATE = PROJDATE;
			ApsFloatType _PROJQTY = PROJQTY;
			ApsOrderType _MATLDELVID = MATLDELVID;
			ApsFloatType _RESERVEDQTY = RESERVEDQTY;
			RowPointerType _SLREF = SLREF;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsEXRCPTSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ORDERID", _ORDERID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EXRCPTDATE", _EXRCPTDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROJDATE", _PROJDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROJQTY", _PROJQTY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATLDELVID", _MATLDELVID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESERVEDQTY", _RESERVEDQTY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLREF", _SLREF, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
