//PROJECT NAME: Production
//CLASS NAME: ApsBATCHSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBATCHSave : IApsBATCHSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsBATCHSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBATCHSaveSp(int? InsertFlag,
		int? AltNo,
		string BATDEFID,
		string DESCR,
		string ITEM,
		int? SEPRL,
		int? QUANRL,
		decimal? QVALUE,
		decimal? MINQUAN,
		decimal? MAXQUAN,
		string ADDOVFG,
		int? OVERRL,
		decimal? OVTHRESH,
		string PEROVFG,
		decimal? OVCYCLE)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsBatchType _BATDEFID = BATDEFID;
			ApsDescriptType _DESCR = DESCR;
			ItemType _ITEM = ITEM;
			ApsBatchSepRlType _SEPRL = SEPRL;
			ApsBatchQuanRlType _QUANRL = QUANRL;
			ApsFloatType _QVALUE = QVALUE;
			ApsFloatType _MINQUAN = MINQUAN;
			ApsFloatType _MAXQUAN = MAXQUAN;
			ApsFlagType _ADDOVFG = ADDOVFG;
			ApsBatchOverRlType _OVERRL = OVERRL;
			ApsFloatType _OVTHRESH = OVTHRESH;
			ApsFlagType _PEROVFG = PEROVFG;
			ApsDurationType _OVCYCLE = OVCYCLE;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsBATCHSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BATDEFID", _BATDEFID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ITEM", _ITEM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SEPRL", _SEPRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QUANRL", _QUANRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QVALUE", _QVALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MINQUAN", _MINQUAN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MAXQUAN", _MAXQUAN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ADDOVFG", _ADDOVFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OVERRL", _OVERRL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OVTHRESH", _OVTHRESH, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEROVFG", _PEROVFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OVCYCLE", _OVCYCLE, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
