//PROJECT NAME: FinanceExt
//CLASS NAME: SLPerSorts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLPerSorts")]
    public class SLPerSorts : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBPerUnitSp(string FSBName,
                                     byte? StartingSortMethod,
                                     byte? EndingSortMethod,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMultiFSBPerUnitExt = new MultiFSBPerUnitFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iMultiFSBPerUnitExt.MultiFSBPerUnitSp(FSBName,
                                                                     StartingSortMethod,
                                                                     EndingSortMethod,
                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBPertotSp(byte? BegSort,
                                    byte? EndSort,
                                    byte? ActiveOnly,
                                    string FSBName,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMultiFSBPertotExt = new MultiFSBPertotFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iMultiFSBPertotExt.MultiFSBPertotSp(BegSort,
                                                                   EndSort,
                                                                   ActiveOnly,
                                                                   FSBName,
                                                                   ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PertotSp(int? BegSort,
		int? EndSort,
		int? ActiveOnly,
		ref string Infobar,
		[Optional] int? ChunkSize)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPertotExt = new PertotFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPertotExt.PertotSp(BegSort,
				EndSort,
				ActiveOnly,
				Infobar,
				ChunkSize);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
        public int PerUnitSp(int? StartingSortMethod,
            int? EndingSortMethod,
            ref string Infobar)
        {
            var iPerUnitExt = new PerUnitFactory().Create(this, true);

            var result = iPerUnitExt.PerUnitSp(StartingSortMethod,
                EndingSortMethod,
                Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }
    }
}
