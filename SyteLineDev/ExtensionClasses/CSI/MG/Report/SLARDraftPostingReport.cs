//PROJECT NAME: ReportExt
//CLASS NAME: SLARDraftPostingReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;
using CSI.Data.Functions;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLARDraftPostingReport")]
    public class SLARDraftPostingReport : CSIExtensionClassBase
    {
      

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARDraftPostingSp([Optional] int? PDisplayDetail,
			[Optional] string PStartingCustomer,
			[Optional] string PEndingCustomer,
			[Optional] string pStartingBankCode,
			[Optional] string pEndingBankCode,
			[Optional] DateTime? pStartingDueDate,
			[Optional] DateTime? pEndingDueDate,
			[Optional] int? pStartingDraftNumber,
			[Optional] int? pEndingDraftNumber,
			[Optional] int? PDisplayHeader,
			[Optional] string PSessionIDChar,
			[Optional] string pSite,
			[Optional] string BGUser)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);
			    IInitSessionContextWithUserFactory initSessionContextWithUserFactory = new InitSessionContextWithUserFactory();
		        ICloseSessionContextFactory closeSessionContextFactory = new CloseSessionContextFactory();
				IGetIsolationLevelFactory getIsolationLevelFactory = new GetIsolationLevelFactory();
				IIsIntegerFactory isIntegerFactory = new IsIntegerFactory();
				IGetLabelFactory getLabelFactory = new GetLabelFactory();
		        var iRpt_ARDraftPostingExt = new Rpt_ARDraftPostingFactory(initSessionContextWithUserFactory, closeSessionContextFactory, getIsolationLevelFactory,
			    isIntegerFactory, getLabelFactory).Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true, this);

				var result = iRpt_ARDraftPostingExt.Rpt_ARDraftPostingSp(PDisplayDetail,
				PStartingCustomer,
				PEndingCustomer,
				pStartingBankCode,
				pEndingBankCode,
				pStartingDueDate,
				pEndingDueDate,
				pStartingDraftNumber,
				pEndingDraftNumber,
				PDisplayHeader,
				PSessionIDChar,
				pSite,
				BGUser);


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
}
