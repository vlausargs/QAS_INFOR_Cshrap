//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConfigCreateUtil.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigCreateUtil
	{
		(int? ReturnCode, string Infobar) SSSFSUnitConfigCreateUtilSP(int? ByJob = 0,
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
        DateTime? ShipDateEnd = null);
	}
}

