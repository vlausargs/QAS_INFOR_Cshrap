//PROJECT NAME: Production
//CLASS NAME: ApsRESRCSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsRESRCSave : IApsRESRCSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsRESRCSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsRESRCSaveSp(int? InsertFlag,
		int? AltNo,
		string RESID,
		string DESCR,
		string RESTYPE,
		string fa_num,
		int? SEQRL,
		int? SELRL,
		int? TIEREDRL1,
		int? TIEREDRL2,
		int? TIEREDRL3,
		decimal? SELVALUE,
		decimal? SETUPDEL,
		string PARTSETUP,
		string ALLOCCD,
		string INFINITEFG,
		string SUPER,
		string SUMFG,
		string SCHEDFG,
		string FINALQFG,
		string LOADFG,
		string SHIFTID1,
		string SHIFTID2,
		string SHIFTID3,
		string SHIFTID4,
		decimal? MAXORUN,
		string MUSTCOMPFG,
		                          int? RESIDQTY,
                                  string plant,
                                  string RESID_alias)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsResourceType _RESID = RESID;
			ApsDescriptType _DESCR = DESCR;
			ApsRestypeType _RESTYPE = RESTYPE;
			FaNumType _fa_num = fa_num;
			ApsResrcSeqRlType _SEQRL = SEQRL;
			ApsResrcSelRlType _SELRL = SELRL;
			ApsResrcSeqRlType _TIEREDRL1 = TIEREDRL1;
			ApsResrcSeqRlType _TIEREDRL2 = TIEREDRL2;
			ApsResrcSeqRlType _TIEREDRL3 = TIEREDRL3;
			ApsSelvalueType _SELVALUE = SELVALUE;
			ApsSetupdelType _SETUPDEL = SETUPDEL;
			ApsPartType _PARTSETUP = PARTSETUP;
			ApsResrcAllocCodeType _ALLOCCD = ALLOCCD;
			ApsFlagType _INFINITEFG = INFINITEFG;
			ApsFlagType _SUPER = SUPER;
			ApsFlagType _SUMFG = SUMFG;
			ApsFlagType _SCHEDFG = SCHEDFG;
			ApsFlagType _FINALQFG = FINALQFG;
			ApsFlagType _LOADFG = LOADFG;
			ApsShiftType _SHIFTID1 = SHIFTID1;
			ApsShiftType _SHIFTID2 = SHIFTID2;
			ApsShiftType _SHIFTID3 = SHIFTID3;
			ApsShiftType _SHIFTID4 = SHIFTID4;
			ApsDurationType _MAXORUN = MAXORUN;
			ApsFlagType _MUSTCOMPFG = MUSTCOMPFG;
			ApsIntType _RESIDQTY = RESIDQTY;
            PlantType _plant = plant;
            ApsResourceAliasType _RESID_alias = RESID_alias;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsRESRCSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESTYPE", _RESTYPE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "fa_num", _fa_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SEQRL", _SEQRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SELRL", _SELRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIEREDRL1", _TIEREDRL1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIEREDRL2", _TIEREDRL2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIEREDRL3", _TIEREDRL3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SELVALUE", _SELVALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SETUPDEL", _SETUPDEL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PARTSETUP", _PARTSETUP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALLOCCD", _ALLOCCD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INFINITEFG", _INFINITEFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SUPER", _SUPER, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SUMFG", _SUMFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCHEDFG", _SCHEDFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FINALQFG", _FINALQFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LOADFG", _LOADFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTID1", _SHIFTID1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTID2", _SHIFTID2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTID3", _SHIFTID3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTID4", _SHIFTID4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MAXORUN", _MAXORUN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MUSTCOMPFG", _MUSTCOMPFG, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RESIDQTY", _RESIDQTY, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "plant", _plant, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RESID_alias", _RESID_alias, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
