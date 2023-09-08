//PROJECT NAME: MaterialExt
//CLASS NAME: SLSitenets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLSitenets")]
    public class SLSitenets : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChangeTransferExchRateSp(string FromSite,
                                                    string ToSite,
                                                    decimal? ExchRate,
                                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iChangeTransferExchRateExt = new ChangeTransferExchRateFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iChangeTransferExchRateExt.ChangeTransferExchRateSp(FromSite,
                                                                       ToSite,
                                                                       ExchRate,
                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetInterSiteCurrDataSp(string PFromSite,
                                                  string PToSite,
                                                  ref string PFromCurrCode,
                                                  ref string PToCurrCode,
                                                  ref decimal? PBuyRate,
                                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetInterSiteCurrDataExt = new GetInterSiteCurrDataFactory().Create(appDb);

                CurrCodeType oPFromCurrCode = PFromCurrCode;
                CurrCodeType oPToCurrCode = PToCurrCode;
                ExchRateType oPBuyRate = PBuyRate;
                Infobar oInfobar = Infobar;

                int Severity = iGetInterSiteCurrDataExt.GetInterSiteCurrDataSp(PFromSite,
                                                                     PToSite,
                                                                     ref oPFromCurrCode,
                                                                     ref oPToCurrCode,
                                                                     ref oPBuyRate,
                                                                     ref oInfobar);

                PFromCurrCode = oPFromCurrCode;
                PToCurrCode = oPToCurrCode;
                PBuyRate = oPBuyRate;
                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSitenetPricecode(string FromSite,
		                               string ToSite,
		                               ref string Pricecode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSitenetPricecodeExt = new GetSitenetPricecodeFactory().Create(appDb);
				
				var result = iGetSitenetPricecodeExt.GetSitenetPricecodeSp(FromSite,
				                                                           ToSite,
				                                                           Pricecode);
				
				int Severity = result.ReturnCode.Value;
				Pricecode = result.Pricecode;
				return Severity;
			}
		}
    }
}
