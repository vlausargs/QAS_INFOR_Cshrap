//PROJECT NAME: Production
//CLASS NAME: IApsSaveAPSOPTIONS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSaveAPSOPTIONS
	{
		int? ApsSaveAPSOPTIONSSp(int? InsertFlag,
		int? AltNo,
		string PARAM,
		string VALUE);
	}
}

