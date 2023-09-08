//PROJECT NAME: ProductExt
//CLASS NAME: SLAltscheds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLAltscheds")]
    public class SLAltscheds : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SchedSetParametersSp(short? AltNo,
                                        string MFBSHIFTID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSchedSetParametersExt = new SchedSetParametersFactory().Create(appDb);

                int Severity = iSchedSetParametersExt.SchedSetParametersSp(AltNo,
                                                                           MFBSHIFTID);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PutAltSchedSp(int? pAltNo,
		DateTime? pStartDate,
		DateTime? pEndDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPutAltSchedExt = new PutAltSchedFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPutAltSchedExt.PutAltSchedSp(pAltNo,
				pStartDate,
				pEndDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
