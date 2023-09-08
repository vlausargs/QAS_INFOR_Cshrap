//PROJECT NAME: Production
//CLASS NAME: IApsSHIFTEXDISave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSHIFTEXDISave
	{
		int? ApsSHIFTEXDISaveSp(int? InsertFlag,
		int? AltNo,
		string SHIFTEXID,
		string DESCR,
		string SHIFTID,
		string TYPECD,
		string RESORTYPE,
		DateTime? STARTDATE,
		DateTime? ENDDATE,
		string WORKFG);
	}
}

