//PROJECT NAME: Production
//CLASS NAME: GeneratePs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class GeneratePs : IGeneratePs
	{
		readonly IApplicationDB appDB;
		
		
		public GeneratePs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PsNum,
		string Infobar,
		int? PsReleasecount) GeneratePsSp(string Item,
		decimal? GenQty,
		decimal? RatePerDay,
		string PsGenType,
		DateTime? MDate,
		int? MdayNum,
		int? PsGenFreq,
		string PsGenStat,
		string PsNum,
		string UpdateJobRel,
		string PsPrefix = null,
		Guid? SessionID = null,
		string Infobar = null,
		int? FromMRP = 0,
		string PLN_Ref_Type = null,
		string PLN_Ref_Num = null,
		int? PLN_ref_suf = null,
		int? CopyToPSItemBOM = null,
		int? CopyToReleaseBOM = null,
		int? PsReleasecount = null)
		{
			ItemType _Item = Item;
			QtyUnitType _GenQty = GenQty;
			RunRateType _RatePerDay = RatePerDay;
			SortDirectionPlusType _PsGenType = PsGenType;
			DateType _MDate = MDate;
			MdayNumType _MdayNum = MdayNum;
			MdaysType _PsGenFreq = PsGenFreq;
			PsStatusType _PsGenStat = PsGenStat;
			PsNumType _PsNum = PsNum;
			StringType _UpdateJobRel = UpdateJobRel;
			PsPrefixType _PsPrefix = PsPrefix;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			ListYesNoType _FromMRP = FromMRP;
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			MrpOrderLineType _PLN_ref_suf = PLN_ref_suf;
			ListYesNoType _CopyToPSItemBOM = CopyToPSItemBOM;
			ListYesNoType _CopyToReleaseBOM = CopyToReleaseBOM;
			IntType _PsReleasecount = PsReleasecount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenQty", _GenQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RatePerDay", _RatePerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsGenType", _PsGenType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MDate", _MDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MdayNum", _MdayNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsGenFreq", _PsGenFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsGenStat", _PsGenStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UpdateJobRel", _UpdateJobRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsPrefix", _PsPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromMRP", _FromMRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Type", _PLN_Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Num", _PLN_Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_ref_suf", _PLN_ref_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyToPSItemBOM", _CopyToPSItemBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyToReleaseBOM", _CopyToReleaseBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsReleasecount", _PsReleasecount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PsNum = _PsNum;
				Infobar = _Infobar;
				PsReleasecount = _PsReleasecount;
				
				return (Severity, PsNum, Infobar, PsReleasecount);
			}
		}
	}
}
