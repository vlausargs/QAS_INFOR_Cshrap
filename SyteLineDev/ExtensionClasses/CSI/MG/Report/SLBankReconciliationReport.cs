//PROJECT NAME: ReportExt
//CLASS NAME: SLBankReconciliationReport.cs

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
    [IDOExtensionClass("SLBankReconciliationReport")]
    public class SLBankReconciliationReport : CSIExtensionClassBase
    {
      

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BankReconciliationSp([Optional] string StartBankCode,
			[Optional] string EndBankCode,
			[Optional] DateTime? StartTransDate,
			[Optional] DateTime? EndTransDate,
			[Optional] int? StartTransNum,
			[Optional] int? EndTransNum,
			[Optional] int? IncludeVoidChecks,
			[Optional] int? IncludeReconciled,
			[Optional] string SortBy,
			[Optional] int? DisplayReasonCodes,
			[Optional] int? DisplayRefFields,
			[Optional] string BankRecTypes,
			[Optional] int? StartDateOffset,
			[Optional] int? EndDateOffset,
			[Optional] int? DisplayHeader,
			[Optional] string BGSessionId,
			[Optional] string pSite,
			[Optional] string BGUser)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);
				IInitSessionContextWithUserFactory initSessionContextWithUserFactory = new InitSessionContextWithUserFactory();
				ICopySessionVariablesFactory copySessionVariablesFactory = new CopySessionVariablesFactory();
				ICloseSessionContextFactory closeSessionContextFactory = new CloseSessionContextFactory();
				IGetIsolationLevelFactory getIsolationLevelFactory = new GetIsolationLevelFactory();
				IApplyDateOffsetFactory applyDateOffsetFactory = new ApplyDateOffsetFactory();
				IGetLabelFactory getLabelFactory = new GetLabelFactory();
				IHighIntFactory highIntFactory = new HighIntFactory();
				ILowIntFactory lowIntFactory = new LowIntFactory();
		        var iRpt_BankReconciliationExt = new Rpt_BankReconciliationFactory(initSessionContextWithUserFactory, copySessionVariablesFactory,
					closeSessionContextFactory, getIsolationLevelFactory, applyDateOffsetFactory, getLabelFactory, highIntFactory, lowIntFactory).Create(appDb,
						bunchedLoadCollection,
						mgInvoker,
						new CSI.Data.SQL.SQLParameterProvider(),
						true, this);

				var result = iRpt_BankReconciliationExt.Rpt_BankReconciliationSp(StartBankCode,
					EndBankCode,
					StartTransDate,
					EndTransDate,
					StartTransNum,
					EndTransNum,
					IncludeVoidChecks,
					IncludeReconciled,
					SortBy,
					DisplayReasonCodes,
					DisplayRefFields,
					BankRecTypes,
					StartDateOffset,
					EndDateOffset,
					DisplayHeader,
					BGSessionId,
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
