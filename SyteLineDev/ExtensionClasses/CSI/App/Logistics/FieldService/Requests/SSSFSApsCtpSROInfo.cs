//PROJECT NAME: Logistics
//CLASS NAME: SSSFSApsCtpSROInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSApsCtpSROInfo : ISSSFSApsCtpSROInfo
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSApsCtpSROInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PApsOrderId,
		int? PCategory,
		int? PFlags,
		DateTime? PApsRequestDate,
		DateTime? PApsDueDate,
		string PApsItem,
		int? PExcludeFromATP,
		DateTime? PSroStartDate) SSSFSApsCtpSROInfoSp(string PSroNum,
		int? PSroLine,
		int? PSroOper,
		int? PTransNum,
		DateTime? PTransDate,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		string PItem,
		string PApsOrderId,
		int? PCategory,
		int? PFlags,
		DateTime? PApsRequestDate,
		DateTime? PApsDueDate,
		string PApsItem,
		int? PExcludeFromATP,
		DateTime? PSroStartDate)
		{
			FSSRONumType _PSroNum = PSroNum;
			FSSROLineType _PSroLine = PSroLine;
			FSSROOperType _PSroOper = PSroOper;
			FSSROTransNumType _PTransNum = PTransNum;
			DateType _PTransDate = PTransDate;
			RefTypeIJKPRTType _PRefType = PRefType;
			JobPoProjReqTrnNumType _PRefNum = PRefNum;
			SuffixPoLineProjTaskReqTrnLineType _PRefLineSuf = PRefLineSuf;
			ItemType _PItem = PItem;
			ApsOrderType _PApsOrderId = PApsOrderId;
			ApsCategoryType _PCategory = PCategory;
			ApsBitFlagsType _PFlags = PFlags;
			DateTimeType _PApsRequestDate = PApsRequestDate;
			DateTimeType _PApsDueDate = PApsDueDate;
			ApsMaterialType _PApsItem = PApsItem;
			ListYesNoType _PExcludeFromATP = PExcludeFromATP;
			DateTimeType _PSroStartDate = PSroStartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSApsCtpSROInfoSp";
				
				appDB.AddCommandParameter(cmd, "PSroNum", _PSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroLine", _PSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroOper", _PSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApsOrderId", _PApsOrderId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCategory", _PCategory, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFlags", _PFlags, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApsRequestDate", _PApsRequestDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApsDueDate", _PApsDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApsItem", _PApsItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExcludeFromATP", _PExcludeFromATP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSroStartDate", _PSroStartDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PApsOrderId = _PApsOrderId;
				PCategory = _PCategory;
				PFlags = _PFlags;
				PApsRequestDate = _PApsRequestDate;
				PApsDueDate = _PApsDueDate;
				PApsItem = _PApsItem;
				PExcludeFromATP = _PExcludeFromATP;
				PSroStartDate = _PSroStartDate;
				
				return (Severity, PApsOrderId, PCategory, PFlags, PApsRequestDate, PApsDueDate, PApsItem, PExcludeFromATP, PSroStartDate);
			}
		}
	}
}
