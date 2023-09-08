//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbLedgers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFsbLedgers")]
    public class SLFsbLedgers : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultIFSBGlCmprPDoProcessSp(Guid? ProcessId,
                                              string PCompressBy,
                                              string PCompressionLevel,
                                              ref byte? RACompressed,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbLedgersExt = new MultIFSBGlCmprPDoProcessFactory().Create(appDb);

                FlagNyType oRACompressed = RACompressed;
                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbLedgersExt.MultIFSBGlCmprPDoProcessSp(ProcessId,
                                                                           PCompressBy,
                                                                           PCompressionLevel,
                                                                           ref oRACompressed,
                                                                           ref oInfobar);

                RACompressed = oRACompressed;
                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MultiFSBLedgerCompressSnapshotSp(Guid? ProcessId,
		                                            DateTime? PTransDateStart,
		                                            DateTime? PTransDateEnd,
		                                            string PAcctStart,
		                                            string PAcctEnd,
		                                            string PFSBNameStart,
		                                            string PFSBNameEnd,
		                                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBLedgerCompressSnapshotExt = new MultiFSBLedgerCompressSnapshotFactory().Create(appDb);
				
				int Severity = iMultiFSBLedgerCompressSnapshotExt.MultiFSBLedgerCompressSnapshotSp(ProcessId,
				                                                                                   PTransDateStart,
				                                                                                   PTransDateEnd,
				                                                                                   PAcctStart,
				                                                                                   PAcctEnd,
				                                                                                   PFSBNameStart,
				                                                                                   PFSBNameEnd,
				                                                                                   ref Infobar);
				
				return Severity;
			}
		}
    }
}
