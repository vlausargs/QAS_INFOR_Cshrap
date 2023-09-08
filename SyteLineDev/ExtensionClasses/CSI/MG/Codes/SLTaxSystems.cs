//PROJECT NAME: CodesExt
//CLASS NAME: SLTaxSystems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLTaxSystems")]
    public class SLTaxSystems : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ActiveForPurchChangedSp(string ActiveForPurch,
                                           byte? TaxSystem,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iActiveForPurchChangedExt = new ActiveForPurchChangedFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iActiveForPurchChangedExt.ActiveForPurchChangedSp(ActiveForPurch,
                                                                                 TaxSystem,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetParamTaxDiscAllowSP(byte? TaxSystem,
                                          ref byte? TaxDiscAllow)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetParamTaxDiscAllowExt = new GetParamTaxDiscAllowFactory().Create(appDb);

                ListYesNoType oTaxDiscAllow = TaxDiscAllow;

                int Severity = iGetParamTaxDiscAllowExt.GetParamTaxDiscAllowSP(TaxSystem,
                                                                               ref oTaxDiscAllow);

                TaxDiscAllow = oTaxDiscAllow;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTaxSystemsCountSp(ref int? TaxSystemCount,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetTaxSystemsCountExt = new GetTaxSystemsCountFactory().Create(appDb);
				
				int Severity = iGetTaxSystemsCountExt.GetTaxSystemsCountSp(ref TaxSystemCount,
				                                                           ref Infobar);
				
				return Severity;
			}
		}
    }
}
