//PROJECT NAME: Production
//CLASS NAME: IApsEFFECTSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsEFFECTSave
	{
		int? ApsEFFECTSaveSp(int? InsertFlag,
		int? AltNo,
		string EFFECTID,
		string DESCR,
		DateTime? STARTDATE,
		DateTime? ENDDATE,
		int? DATETYPE,
		int? CONDITION,
		string VALUE,
		string PartNo,
		string Contract);
	}
}

