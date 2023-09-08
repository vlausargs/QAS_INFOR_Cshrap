//PROJECT NAME: Logistics
//CLASS NAME: IGetChartInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetChartInfo
	{
		(int? ReturnCode, string rChartType,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar,
		int? rIsControl) GetChartInfoSp(string pChartAcct,
		string rChartType,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar,
		string Site = null,
		int? rIsControl = null);
	}
}

