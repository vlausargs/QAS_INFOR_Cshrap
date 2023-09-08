//PROJECT NAME: APSExt
//CLASS NAME: SLShortages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLShortages")]
    public class SLShortages : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetShortagesSp(string DemandType,
            string DemandRef,
            string Item,
            string PlannerCode,
            DateTime? StartDate,
            DateTime? DueDate,
            int? AltNo,
            [Optional] string ProductCode,
            [Optional] string FilterString)
        {
            var iCLM_ApsGetShortagesExt = new CLM_ApsGetShortagesFactory().Create(this, true);

            var result = iCLM_ApsGetShortagesExt.CLM_ApsGetShortagesSp(DemandType,
                DemandRef,
                Item,
                PlannerCode,
                StartDate,
                DueDate,
                AltNo,
                ProductCode,
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