//PROJECT NAME: ReportExt
//CLASS NAME: SLMailingLabelsReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLMailingLabelsReport")]
    public class SLMailingLabelsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MailingLabelsSp([Optional] string GenerateLabelFor,
		[Optional] string CEVType,
		[Optional] int? SortByPostCode,
		[Optional] int? PrintCountry,
		[Optional] string PrintWhichCustomerContact,
		[Optional] string NameStarting,
		[Optional] string NameEnding,
		[Optional] string CEVStarting,
		[Optional] string CEVEnding,
		[Optional] string ProvinceStateStarting,
		[Optional] string ProvinceStateEnding,
		[Optional] string PostalZipStarting,
		[Optional] string PostalZipEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MailingLabelsExt = new Rpt_MailingLabelsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MailingLabelsExt.Rpt_MailingLabelsSp(GenerateLabelFor,
				CEVType,
				SortByPostCode,
				PrintCountry,
				PrintWhichCustomerContact,
				NameStarting,
				NameEnding,
				CEVStarting,
				CEVEnding,
				ProvinceStateStarting,
				ProvinceStateEnding,
				PostalZipStarting,
				PostalZipEnding,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
