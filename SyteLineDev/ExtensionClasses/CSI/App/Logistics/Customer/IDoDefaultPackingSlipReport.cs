//PROJECT NAME: Logistics
//CLASS NAME: IDoDefaultPackingSlipReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IDoDefaultPackingSlipReport
	{
		(int? ReturnCode, int? PackNum,
		string Infobar) DoDefaultPackingSlipReportSp(string TPckCall,
		string Whse,
		DateTime? PackDate,
		string CoNum,
		int? PackNum,
		string Infobar,
		int? BatchId);
	}
}

