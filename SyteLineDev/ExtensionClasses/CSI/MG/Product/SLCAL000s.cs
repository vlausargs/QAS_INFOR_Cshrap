//PROJECT NAME: ProductExt
//CLASS NAME: SLCAL000s.cs

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
    [IDOExtensionClass("SLCAL000s")]
    public class SLCAL000s : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Cal000MrpDatesSp(short? AltNo,
                                    ref DateTime? PStartDate,
                                    ref DateTime? PEndDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCal000MrpDatesExt = new Cal000MrpDatesFactory().Create(appDb);

                DateType oPStartDate = PStartDate;
                DateType oPEndDate = PEndDate;

                int Severity = iCal000MrpDatesExt.Cal000MrpDatesSp(AltNo,
                                                                   ref oPStartDate,
                                                                   ref oPEndDate);

                PStartDate = oPStartDate;
                PEndDate = oPEndDate;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int Cal000BldHldyMcalSp(int? PTSfcFlag,
		DateTime? PTMdayDate,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCal000BldHldyMcalExt = new Cal000BldHldyMcalFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCal000BldHldyMcalExt.Cal000BldHldyMcalSp(PTSfcFlag,
				PTMdayDate,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
