//PROJECT NAME: Production
//CLASS NAME: ApsJOBSTEPSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsJOBSTEPSave : IApsJOBSTEPSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsJOBSTEPSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsJOBSTEPSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string WORKCENTER,
		string JSID,
		string DESCR,
		string STEPEXP,
		int? STEPEXPRL,
		string RESACTN1,
		string RESACTN2,
		string RESACTN3,
		string RESACTN4,
		string RESACTN5,
		string RESACTN6,
		string RESID1,
		string RESID2,
		string RESID3,
		string RESID4,
		string RESID5,
		string RESID6,
		int? RESNMBR1,
		int? RESNMBR2,
		int? RESNMBR3,
		int? RESNMBR4,
		int? RESNMBR5,
		int? RESNMBR6,
		decimal? STEPTIME,
		int? STEPTMRL,
		DateTime? EFFDATE,
		DateTime? OBSDATE,
		string RGID,
		string TABID,
		int? WHENRL,
		string BASEDCD,
		decimal? SETUPTIME,
		string STIMEXP,
		int? STIMEXPRL,
		decimal? MOVETIME,
		decimal? QTIME,
		decimal? COOLTIME,
		int? CRSBRKRL,
		int? OLTYPE,
		decimal? OLVALUE,
		decimal? SPLITSIZE,
		string BATCHDEF,
		int? SPLITRULE,
		string SPLITGROUP)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsProcplanType _PROCPLANID = PROCPLANID;
			ApsWorkCenterType _WORKCENTER = WORKCENTER;
			ApsJobstepType _JSID = JSID;
			ApsDescriptType _DESCR = DESCR;
			ApsExprType _STEPEXP = STEPEXP;
			ApsJsStepexpRlType _STEPEXPRL = STEPEXPRL;
			ApsJsResActnCodeType _RESACTN1 = RESACTN1;
			ApsJsResActnCodeType _RESACTN2 = RESACTN2;
			ApsJsResActnCodeType _RESACTN3 = RESACTN3;
			ApsJsResActnCodeType _RESACTN4 = RESACTN4;
			ApsJsResActnCodeType _RESACTN5 = RESACTN5;
			ApsJsResActnCodeType _RESACTN6 = RESACTN6;
			ApsResrefType _RESID1 = RESID1;
			ApsResrefType _RESID2 = RESID2;
			ApsResrefType _RESID3 = RESID3;
			ApsResrefType _RESID4 = RESID4;
			ApsResrefType _RESID5 = RESID5;
			ApsResrefType _RESID6 = RESID6;
			ApsSmallIntType _RESNMBR1 = RESNMBR1;
			ApsSmallIntType _RESNMBR2 = RESNMBR2;
			ApsSmallIntType _RESNMBR3 = RESNMBR3;
			ApsSmallIntType _RESNMBR4 = RESNMBR4;
			ApsSmallIntType _RESNMBR5 = RESNMBR5;
			ApsSmallIntType _RESNMBR6 = RESNMBR6;
			ApsFloatType _STEPTIME = STEPTIME;
			ApsJsSteptmRlType _STEPTMRL = STEPTMRL;
			DateTimeType _EFFDATE = EFFDATE;
			DateTimeType _OBSDATE = OBSDATE;
			ApsResgroupType _RGID = RGID;
			ApsLtableType _TABID = TABID;
			ApsJs19WhenRlType _WHENRL = WHENRL;
			ApsJsBasedCodeType _BASEDCD = BASEDCD;
			ApsDurationType _SETUPTIME = SETUPTIME;
			ApsExprType _STIMEXP = STIMEXP;
			ApsJsStepexpRlType _STIMEXPRL = STIMEXPRL;
			ApsDurationType _MOVETIME = MOVETIME;
			ApsDurationType _QTIME = QTIME;
			ApsDurationType _COOLTIME = COOLTIME;
			ApsJs19CrsBrkRlType _CRSBRKRL = CRSBRKRL;
			ApsJs19OlTypeType _OLTYPE = OLTYPE;
			ApsFloatType _OLVALUE = OLVALUE;
			ApsFloatType _SPLITSIZE = SPLITSIZE;
			ApsBatchType _BATCHDEF = BATCHDEF;
			ApsSplitRuleType _SPLITRULE = SPLITRULE;
			ApsResgroupType _SPLITGROUP = SPLITGROUP;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsJOBSTEPSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PROCPLANID", _PROCPLANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WORKCENTER", _WORKCENTER, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JSID", _JSID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STEPEXP", _STEPEXP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STEPEXPRL", _STEPEXPRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESACTN1", _RESACTN1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESACTN2", _RESACTN2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESACTN3", _RESACTN3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESACTN4", _RESACTN4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESACTN5", _RESACTN5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESACTN6", _RESACTN6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID1", _RESID1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID2", _RESID2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID3", _RESID3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID4", _RESID4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID5", _RESID5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID6", _RESID6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESNMBR1", _RESNMBR1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESNMBR2", _RESNMBR2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESNMBR3", _RESNMBR3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESNMBR4", _RESNMBR4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESNMBR5", _RESNMBR5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESNMBR6", _RESNMBR6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STEPTIME", _STEPTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STEPTMRL", _STEPTMRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFFDATE", _EFFDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OBSDATE", _OBSDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RGID", _RGID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TABID", _TABID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WHENRL", _WHENRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BASEDCD", _BASEDCD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SETUPTIME", _SETUPTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STIMEXP", _STIMEXP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STIMEXPRL", _STIMEXPRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MOVETIME", _MOVETIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QTIME", _QTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COOLTIME", _COOLTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CRSBRKRL", _CRSBRKRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OLTYPE", _OLTYPE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OLVALUE", _OLVALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPLITSIZE", _SPLITSIZE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BATCHDEF", _BATCHDEF, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPLITRULE", _SPLITRULE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPLITGROUP", _SPLITGROUP, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
