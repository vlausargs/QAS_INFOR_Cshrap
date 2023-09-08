//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimateStatusReport.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;
using CSI.Data.Functions;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLEstimateStatusReport")]
    public class SLEstimateStatusReport : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_EstimateStatusSp([Optional] string OrderStarting,
                    [Optional] string OrderEnding,
                    [Optional] string EstStatus,
                    [Optional] string CustomerStarting,
                    [Optional] string CustomerEnding,
                    [Optional] DateTime? QuoteDateStarting,
                    [Optional] DateTime? QuoteDateEnding,
                    [Optional] int? QuoteDateStartingOffset,
                    [Optional] int? QuoteDateEndingOffset,
                    [Optional] DateTime? ExpDateStarting,
                    [Optional] DateTime? ExpDateEnding,
                    [Optional] int? ExpDateStartingOffset,
                    [Optional] int? ExpDateEndingOffset,
                    [Optional] string ItemStarting,
                    [Optional] string ItemEnding,
                    [Optional] string CustItemStarting,
                    [Optional] string CustItemEnding,
                    [Optional] DateTime? DueDateStarting,
                    [Optional] DateTime? DueDateEnding,
                    [Optional] int? DueDateStartingOffset,
                    [Optional] int? DueDateEndingOffset,
                    [Optional] int? PrintDetail,
                    [Optional] string SortBy,
                    [Optional] int? ShowCONotes,
                    [Optional] int? ShowLineRelNotes,
                    [Optional] int? ShowInternal,
                    [Optional] int? ShowExternal,
                    [Optional, DefaultParameterValue(0)] int? PrintCost,
                    [Optional] int? DisplayHeader,
                    [Optional] string StartProspect,
                    [Optional] string EndProspect,
                    [Optional] string BGSessionId,
                    [Optional] string pSite,
                    [Optional] string BGUser)
        {
                IInitSessionContextWithUserFactory initSessionContextWithUserFactory = new InitSessionContextWithUserFactory();
                ICopySessionVariablesFactory copySessionVariablesFactory = new CopySessionVariablesFactory();
                ICloseSessionContextFactory closeSessionContextFactory = new CloseSessionContextFactory();
                IGetIsolationLevelFactory getIsolationLevelFactory = new GetIsolationLevelFactory();
                IApplyDateOffsetFactory applyDateOffsetFactory = new ApplyDateOffsetFactory();              
                IGetLabelFactory getLabelFactory = new GetLabelFactory();               
                var iRpt_EstimateStatusExt = new Rpt_EstimateStatusFactory(
                     initSessionContextWithUserFactory,
                     copySessionVariablesFactory,
                     closeSessionContextFactory,
                     getIsolationLevelFactory,
                     applyDateOffsetFactory,
                     getLabelFactory).Create(this,
                        true);

                var result = iRpt_EstimateStatusExt.Rpt_EstimateStatusSp(OrderStarting,
                    OrderEnding,
                    EstStatus,
                    CustomerStarting,
                    CustomerEnding,
                    QuoteDateStarting,
                    QuoteDateEnding,
                    QuoteDateStartingOffset,
                    QuoteDateEndingOffset,
                    ExpDateStarting,
                    ExpDateEnding,
                    ExpDateStartingOffset,
                    ExpDateEndingOffset,
                    ItemStarting,
                    ItemEnding,
                    CustItemStarting,
                    CustItemEnding,
                    DueDateStarting,
                    DueDateEnding,
                    DueDateStartingOffset,
                    DueDateEndingOffset,
                    PrintDetail,
                    SortBy,
                    ShowCONotes,
                    ShowLineRelNotes,
                    ShowInternal,
                    ShowExternal,
                    PrintCost,
                    DisplayHeader,
                    StartProspect,
                    EndProspect,
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
