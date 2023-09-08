//PROJECT NAME: Reporting
//CLASS NAME: IRpt_EstimateJobCostDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_EstimateJobCostDetail
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Rpt_EstimateJobCostDetailSp(
            string ExOpordnumStarting = null,
            string ExOpordnumENDing = null,
            string ExOptgoOrdType = null,
            int? ExOpsuffixStarting = null,
            int? ExOpsuffixENDing = null,
            string ExOptdfEjobStat = null,
            string ExOptacCostComponent = null,
            string ExOpjobStarting = null,
            string ExOpjobENDing = null,
            string ExOpItemStarting = null,
            string ExOpItemENDing = null,
            string ExOpCustStarting = null,
            string ExOpCustENDing = null,
            DateTime? ExOpJobDateStarting = null,
            DateTime? ExOpJobDateENDing = null,
            int? DateStartingOffset = null,
            int? DateENDingOffset = null,
            int? DisplayHeader = null,
            string StartProspect = null,
            string EndProspect = null,
            string pSite = null);
    }
}

