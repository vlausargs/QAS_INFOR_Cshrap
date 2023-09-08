//PROJECT NAME: Production
//CLASS NAME: ApsEFFECTSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsEFFECTSave : IApsEFFECTSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsEFFECTSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsEFFECTSaveSp(int? InsertFlag,
		int? AltNo,
		string EFFECTID,
		string DESCR,
		DateTime? STARTDATE,
		DateTime? ENDDATE,
		int? DATETYPE,
		int? CONDITION,
		string VALUE,
		string PartNo,
		string Contract)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsEffectType _EFFECTID = EFFECTID;
			ApsDescriptType _DESCR = DESCR;
			DateTimeType _STARTDATE = STARTDATE;
			DateTimeType _ENDDATE = ENDDATE;
			ApsEffDateTypeType _DATETYPE = DATETYPE;
			ApsSmallIntType _CONDITION = CONDITION;
			ApsEffvalType _VALUE = VALUE;
			PartNoType _PartNo = PartNo;
			ContractType _Contract = Contract;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsEFFECTSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFFECTID", _EFFECTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STARTDATE", _STARTDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDDATE", _ENDDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DATETYPE", _DATETYPE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CONDITION", _CONDITION, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VALUE", _VALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartNo", _PartNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
