//PROJECT NAME: PmfExt
//CLASS NAME: PmfTmpRptPnsBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfTmpRptPnsBase")]
	public class PmfTmpRptPnsBase : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable PmfRptSelectSessPns(Guid? SessionId,
            int? Seq,
            [Optional, DefaultParameterValue(0)] int? ClearSess)
        {
            var iPmfRptSelectSessPnsExt = new PmfRptSelectSessPnsFactory().Create(this, true);

            var result = iPmfRptSelectSessPnsExt.PmfRptSelectSessPnsSp(SessionId,
                Seq,
                ClearSess);

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
