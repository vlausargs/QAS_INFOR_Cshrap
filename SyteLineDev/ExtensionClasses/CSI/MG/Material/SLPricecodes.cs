//PROJECT NAME: MaterialExt
//CLASS NAME: SLPricecodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Vendor;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLPricecodes")]
	public class SLPricecodes : ExtensionClassBase
	{        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TH_THGenerateNewVendInvSeqSp([Optional, DefaultParameterValue(null)] string VendorNum,
                                                [Optional] int? voucher,
                                                [Optional] DateTime? InvDate,
                                                ref string Newvendinv,
                                                ref string Newwhtseq,
                                                [Optional] Guid? ThapptcdRp)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTHGenerateNewVendInvSeqExt = new THGenerateNewVendInvSeqFactory().Create(appDb);

                var result = iTHGenerateNewVendInvSeqExt.THGenerateNewVendInvSeqSp(VendorNum,
                                                                                   voucher,
                                                                                   InvDate,
                                                                                   Newvendinv,
                                                                                   Newwhtseq,
                                                                                   ThapptcdRp);

                int Severity = result.ReturnCode.Value;
                Newvendinv = result.Newvendinv;
                Newwhtseq = result.Newwhtseq;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PriceCodeValid(string PriceCode,
		                          ref string PriceCodeDesc,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPriceCodeValidExt = new PriceCodeValidFactory().Create(appDb);
				
				var result = iPriceCodeValidExt.PriceCodeValidSp(PriceCode,
				                                                 PriceCodeDesc,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				PriceCodeDesc = result.PriceCodeDesc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferPriceCodeValid(string TrnNum,
		                                  string Pricecode,
		                                  string Item,
		                                  decimal? QtyReq,
		                                  ref string PricecodeDesc,
		                                  ref decimal? UnitPrice,
		                                  ref decimal? ExtPrice,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTransferPriceCodeValidExt = new TransferPriceCodeValidFactory().Create(appDb);
				
				var result = iTransferPriceCodeValidExt.TransferPriceCodeValidSp(TrnNum,
				                                                                 Pricecode,
				                                                                 Item,
				                                                                 QtyReq,
				                                                                 PricecodeDesc,
				                                                                 UnitPrice,
				                                                                 ExtPrice,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				PricecodeDesc = result.PricecodeDesc;
				UnitPrice = result.UnitPrice;
				ExtPrice = result.ExtPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
