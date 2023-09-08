//PROJECT NAME: CustomerExt
//CLASS NAME: SLEdiBols.cs

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
    [IDOExtensionClass("SLEdiBols")]
    public class SLEdiBols : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RetransmitEdiASNSp([Optional] string CustomerStarting,
                                      [Optional] string CustomerEnding,
                                      [Optional] DateTime? CDateStarting,
                                      [Optional] DateTime? CDateEnding,
                                      [Optional] short? CDateStartingOffset,
                                      [Optional] short? CDateEndingOffset,
                                      [Optional, DefaultParameterValue((byte)1)] byte? ProcessFlag,
        [Optional] ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRetransmitEdiASNExt = new RetransmitEdiASNFactory().Create(appDb);

                var result = iRetransmitEdiASNExt.RetransmitEdiASNSp(CustomerStarting,
                                                                     CustomerEnding,
                                                                     CDateStarting,
                                                                     CDateEnding,
                                                                     CDateStartingOffset,
                                                                     CDateEndingOffset,
                                                                     ProcessFlag,
                                                                     Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        public DataTable CLM_RetransmitEdiASNSp([Optional] string CustomerStarting,
                                            [Optional] string CustomerEnding,
                                            [Optional] DateTime? CDateStarting,
                                            [Optional] DateTime? CDateEnding,
                                            [Optional] short? CDateStartingOffset,
                                            [Optional] short? CDateEndingOffset,
                                            [Optional, DefaultParameterValue((byte)1)] byte? ProcessFlag,
        [Optional] ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iRetransmitEdiASNExt = new CLM_RetransmitEdiASNFactory().Create(appDb, bunchedLoadCollection);

                var result = iRetransmitEdiASNExt.CLM_RetransmitEdiASNSp(CustomerStarting,
                                                                     CustomerEnding,
                                                                     CDateStarting,
                                                                     CDateEnding,
                                                                     CDateStartingOffset,
                                                                     CDateEndingOffset,
                                                                     ProcessFlag,
                                                                     Infobar);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                Infobar = result.Infobar;
                return dt;
            }
        }
    }
}
