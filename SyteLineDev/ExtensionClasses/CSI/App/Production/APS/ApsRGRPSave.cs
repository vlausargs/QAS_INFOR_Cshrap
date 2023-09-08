//PROJECT NAME: Production
//CLASS NAME: ApsRGRPSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsRGRPSave : IApsRGRPSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsRGRPSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsRGRPSaveSp(int? InsertFlag,
		int? AltNo,
		string RGID,
		string DESCR,
		string SLTYPE,
		decimal? BUFFERIN,
		decimal? BUFFEROUT,
		decimal? INFCAP,
		int? ALLOCRL,
		string INFINITEFG,
		string REALLOCFG,
		string LOADFG,
		                         string SUMFG,
                                 string plant,
                                 string RGID_alias)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsResgroupType _RGID = RGID;
			ApsDescriptType _DESCR = DESCR;
			ApsCodeType _SLTYPE = SLTYPE;
			ApsDurationType _BUFFERIN = BUFFERIN;
			ApsDurationType _BUFFEROUT = BUFFEROUT;
			ApsDurationType _INFCAP = INFCAP;
			ApsRgrpAllocRlType _ALLOCRL = ALLOCRL;
			ApsFlagType _INFINITEFG = INFINITEFG;
			ApsFlagType _REALLOCFG = REALLOCFG;
			ApsFlagType _LOADFG = LOADFG;
			ApsFlagType _SUMFG = SUMFG;
            PlantType _plant = plant;
            ApsResgroupAliasType _RGID_alias = RGID_alias;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsRGRPSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RGID", _RGID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLTYPE", _SLTYPE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BUFFERIN", _BUFFERIN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BUFFEROUT", _BUFFEROUT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INFCAP", _INFCAP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALLOCRL", _ALLOCRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INFINITEFG", _INFINITEFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "REALLOCFG", _REALLOCFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LOADFG", _LOADFG, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SUMFG", _SUMFG, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "plant", _plant, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RGID_alias", _RGID_alias, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
