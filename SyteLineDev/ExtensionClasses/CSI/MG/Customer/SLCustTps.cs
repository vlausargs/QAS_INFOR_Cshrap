//PROJECT NAME: CustomerExt
//CLASS NAME: SLCustTps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCustTps")]
    public class SLCustTps : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CARaSSetCustExtractDateSp(string StartCustNum,
		                                     string EndCustNum,
		                                     byte? ExtractAll,
		                                     DateTime? ExtractDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCARaSSetCustExtractDateExt = new CARaSSetCustExtractDateFactory().Create(appDb);
				
				int Severity = iCARaSSetCustExtractDateExt.CARaSSetCustExtractDateSp(StartCustNum,
				                                                                     EndCustNum,
				                                                                     ExtractAll,
				                                                                     ExtractDate);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckDoSeqsForEdiCustSp(string CustNum,
		                                   int? CustSeq,
		                                   byte? GenInv,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckDoSeqsForEdiCustExt = new CheckDoSeqsForEdiCustFactory().Create(appDb);
				
				int Severity = iCheckDoSeqsForEdiCustExt.CheckDoSeqsForEdiCustSp(CustNum,
				                                                                 CustSeq,
				                                                                 GenInv,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCustProfileExistsSp(string PCustNum,
                                          int? PCustSeq,
                                          ref byte? PProfileExists,
                                          ref byte? PGenInv)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCustProfileExistsExt = new EdiCustProfileExistsFactory().Create(appDb);

                int Severity = iEdiCustProfileExistsExt.EdiCustProfileExistsSp(PCustNum,
                                                                               PCustSeq,
                                                                               ref PProfileExists,
                                                                               ref PGenInv);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CARaSSetItemExtractDateSp(string StartCustNum,
		                                     string EndCustNum,
		                                     byte? ExtractAll,
		                                     DateTime? ExtractDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCARaSSetItemExtractDateExt = new CARaSSetItemExtractDateFactory().Create(appDb);
				
				int Severity = iCARaSSetItemExtractDateExt.CARaSSetItemExtractDateSp(StartCustNum,
				                                                                     EndCustNum,
				                                                                     ExtractAll,
				                                                                     ExtractDate);
				
				return Severity;
			}
		}
    }
}
