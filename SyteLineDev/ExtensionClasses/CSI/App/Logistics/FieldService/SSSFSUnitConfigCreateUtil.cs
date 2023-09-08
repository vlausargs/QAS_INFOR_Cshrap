//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigCreateUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigCreateUtil : ISSSFSUnitConfigCreateUtil
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSUnitConfigCreateUtil(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSUnitConfigCreateUtilSP(int? ByJob = 0,
		string JobStart = null,
		int? JobSufStart = null,
		string ItemJobStart = null,
		string ProductCodeStart = null,
		DateTime? JobDateStart = null,
		int? JobDateStartOffSET = null,
		string JobEND = null,
		int? JobSufEND = null,
		string ItemJobEND = null,
		string ProductCodeEND = null,
		DateTime? JobDateEND = null,
		int? JobDateEndOffSET = null,
		int? BySerNum = 0,
		string SerNumStart = null,
		string ItemSerNumStart = null,
		string SerNumEND = null,
		string ItemSerNumEND = null,
		int? SubCompUnits = null,
		int? NonSerUnits = null,
		string NonSerPrefix = null,
		string Infobar = null,
        DateTime? ShipDateStart = null,
        DateTime? ShipDateEnd = null)
		{
			ListYesNoType _ByJob = ByJob;
			JobType _JobStart = JobStart;
			SuffixType _JobSufStart = JobSufStart;
			ItemType _ItemJobStart = ItemJobStart;
			ProductCodeType _ProductCodeStart = ProductCodeStart;
			DateType _JobDateStart = JobDateStart;
			DateOffsetType _JobDateStartOffSET = JobDateStartOffSET;
			JobType _JobEND = JobEND;
			SuffixType _JobSufEND = JobSufEND;
			ItemType _ItemJobEND = ItemJobEND;
			ProductCodeType _ProductCodeEND = ProductCodeEND;
			DateType _JobDateEND = JobDateEND;
			DateOffsetType _JobDateEndOffSET = JobDateEndOffSET;
			ListYesNoType _BySerNum = BySerNum;
			SerNumType _SerNumStart = SerNumStart;
			ItemType _ItemSerNumStart = ItemSerNumStart;
			SerNumType _SerNumEND = SerNumEND;
			ItemType _ItemSerNumEND = ItemSerNumEND;
			ListYesNoType _SubCompUnits = SubCompUnits;
			ListYesNoType _NonSerUnits = NonSerUnits;
			SerialPrefixType _NonSerPrefix = NonSerPrefix;
			InfobarType _Infobar = Infobar;
            DateType _ShipDateStart = ShipDateStart;
            DateType _ShipDateEnd = ShipDateEnd;

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigCreateUtilSP";
				
				appDB.AddCommandParameter(cmd, "ByJob", _ByJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStart", _JobStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSufStart", _JobSufStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemJobStart", _ItemJobStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStart", _ProductCodeStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStart", _JobDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStartOffSET", _JobDateStartOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEND", _JobEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSufEND", _JobSufEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemJobEND", _ItemJobEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEND", _ProductCodeEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEND", _JobDateEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEndOffSET", _JobDateEndOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BySerNum", _BySerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumStart", _SerNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemSerNumStart", _ItemSerNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumEND", _SerNumEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemSerNumEND", _ItemSerNumEND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubCompUnits", _SubCompUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonSerUnits", _NonSerUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonSerPrefix", _NonSerPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipDateStart", _ShipDateStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipDateEnd", _ShipDateEnd, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
