//PROJECT NAME: CustomerExt
//CLASS NAME: SLAcks.cs

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
    [IDOExtensionClass("SLAcks")]
    public class SLAcks : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_RetransmitEdiAckSp([Optional] string CoNumStarting,
                                                    [Optional] string CoNumEnding,
                                                    [Optional] string CustomerStarting,
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

                var iCLM_RetransmitEdiAckExt = new CLM_RetransmitEdiAckFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_RetransmitEdiAckExt.CLM_RetransmitEdiAckSp(CoNumStarting,
                                                                     CoNumEnding,
                                                                     CustomerStarting,
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

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RetransmitEdiAckSp([Optional] string CoNumStarting,
                                       [Optional] string CoNumEnding,
                                       [Optional] string CustomerStarting,
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

                var iRetransmitEdiAckExt = new RetransmitEdiAckFactory().Create(appDb);

                var result = iRetransmitEdiAckExt.RetransmitEdiAckSp(CoNumStarting,
                                                                     CoNumEnding,
                                                                     CustomerStarting,
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDIPoAckSp([Optional] string CustomerStarting,
		                           [Optional] string CustomerEnding,
		                           [Optional] DateTime? CDateStarting,
		                           [Optional] DateTime? CDateEnding,
		                           [Optional] string Posted,
		                           [Optional] short? CDateStartingOffset,
		                           [Optional] short? CDateEndingOffset,
		                           [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeEDIPoAckExt = new PurgeEDIPoAckFactory().Create(appDb);
				
				var result = iPurgeEDIPoAckExt.PurgeEDIPoAckSp(CustomerStarting,
				                                               CustomerEnding,
				                                               CDateStarting,
				                                               CDateEnding,
				                                               Posted,
				                                               CDateStartingOffset,
				                                               CDateEndingOffset,
				                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
