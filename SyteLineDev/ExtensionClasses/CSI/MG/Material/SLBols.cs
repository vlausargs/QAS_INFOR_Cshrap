//PROJECT NAME: MaterialExt
//CLASS NAME: SLBols.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLBols")]
    public class SLBols : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ASNRecalcSp(string TrnNum,
                                       string BolNum,
                                       ref decimal? NewFreightCharges,
                                       ref decimal? NewCodAmount,
                                       ref decimal? NewTotalCharges,
                                       ref string PromptMsg,
                                       ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iASNRecalcExt = new ASNRecalcFactory().Create(appDb);

                AmountType oNewFreightCharges = NewFreightCharges;
                AmountType oNewCodAmount = NewCodAmount;
                AmountType oNewTotalCharges = NewTotalCharges;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;

                int Severity = iASNRecalcExt.ASNRecalcSp(TrnNum,
                                                      BolNum,
                                                      ref oNewFreightCharges,
                                                      ref oNewCodAmount,
                                                      ref oNewTotalCharges,
                                                      ref oPromptMsg,
                                                      ref oPromptButtons);

                NewFreightCharges = oNewFreightCharges;
                NewCodAmount = oNewCodAmount;
                NewTotalCharges = oNewTotalCharges;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoBolPackSp(string PTrnNum,
                                       int? PPackSlip,
                                       ref string PBolNum,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoBolPackExt = new CoBolPackFactory().Create(appDb);

                BolNumType oPBolNum = PBolNum;
                InfobarType oInfobar = Infobar;

                int Severity = iCoBolPackExt.CoBolPackSp(PTrnNum,
                                                      PPackSlip,
                                                      ref oPBolNum,
                                                      ref oInfobar);

                PBolNum = oPBolNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoBolSp(string PTrnNum,
                                   ref string BolNum,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoBolExt = new CoBolFactory().Create(appDb);

                BolNumType oBolNum = BolNum;
                InfobarType oInfobar = Infobar;

                int Severity = iCoBolExt.CoBolSp(PTrnNum,
                                                  ref oBolNum,
                                                  ref oInfobar);

                BolNum = oBolNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoInitBolSp(string PTrnNum,
                                       string PBolNum,
                                       int? PPackNum,
                                       byte? PCopyFromPackSlip,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoInitBolExt = new CoInitBolFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCoInitBolExt.CoInitBolSp(PTrnNum,
                                                      PBolNum,
                                                      PPackNum,
                                                      PCopyFromPackSlip,
                                                      ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ASNUpdateValueSp(string PTrnNum,
		string PBolNum,
		ref decimal? PValueAmount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iASNUpdateValueExt = new ASNUpdateValueFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iASNUpdateValueExt.ASNUpdateValueSp(PTrnNum,
				PBolNum,
				PValueAmount);
				
				int Severity = result.ReturnCode.Value;
				PValueAmount = result.PValueAmount;
				return Severity;
			}
		}
    }
}
