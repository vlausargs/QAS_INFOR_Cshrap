//PROJECT NAME: CustomerExt
//CLASS NAME: SLSalesForecastOpportunities.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLSalesForecastOpportunities")]
	public class SLSalesForecastOpportunities : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SalespersonForecastOppsSP(string ForecastId,
			int? IncludeDirReports,
			string FilterString)
		{
			var iCLM_SalespersonForecastOppsExt = new CLM_SalespersonForecastOppsFactory().Create(this, true);

			var result = iCLM_SalespersonForecastOppsExt.CLM_SalespersonForecastOppsSP(ForecastId,
				IncludeDirReports,
				FilterString);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
