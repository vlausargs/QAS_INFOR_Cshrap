//PROJECT NAME: RFQExt
//CLASS NAME: RFQHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.RFQ;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RFQ
{
    [IDOExtensionClass("RFQHdrs")]
    public class RFQHdrs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQRFQGetItemInfoSp(string Item,
                                          ref string Description,
                                          ref string UM,
                                          ref string BadItemMsg,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQRFQGetItemInfoExt = new SSSRFQRFQGetItemInfoFactory().Create(appDb);

                int Severity = iSSSRFQRFQGetItemInfoExt.SSSRFQRFQGetItemInfoSp(Item,
                                                                               ref Description,
                                                                               ref UM,
                                                                               ref BadItemMsg,
                                                                               ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQUpdateLineBrkQtySp(string RFQNum,
                                            int? RFQLine,
                                            decimal? BrkQtyConv1,
                                            decimal? BrkQtyConv2,
                                            decimal? BrkQtyConv3,
                                            decimal? BrkQtyConv4,
                                            decimal? BrkQtyConv5,
                                            decimal? BrkQtyConv6,
                                            decimal? BrkQtyConv7,
                                            decimal? BrkQtyConv8,
                                            decimal? BrkQtyConv9,
                                            decimal? BrkQtyConv10,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQUpdateLineBrkQtyExt = new SSSRFQUpdateLineBrkQtyFactory().Create(appDb);

                int Severity = iSSSRFQUpdateLineBrkQtyExt.SSSRFQUpdateLineBrkQtySp(RFQNum,
                                                                                   RFQLine,
                                                                                   BrkQtyConv1,
                                                                                   BrkQtyConv2,
                                                                                   BrkQtyConv3,
                                                                                   BrkQtyConv4,
                                                                                   BrkQtyConv5,
                                                                                   BrkQtyConv6,
                                                                                   BrkQtyConv7,
                                                                                   BrkQtyConv8,
                                                                                   BrkQtyConv9,
                                                                                   BrkQtyConv10,
                                                                                   ref Infobar);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQGenCleanupSp(string PSessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQGenCleanupExt = new SSSRFQGenCleanupFactory().Create(appDb);
				
				var result = iSSSRFQGenCleanupExt.SSSRFQGenCleanupSp(PSessionId);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQDefaultsSp(ref string Buyer,
		ref DateTime? ReplyDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSRFQDefaultsExt = new SSSRFQDefaultsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSRFQDefaultsExt.SSSRFQDefaultsSp(Buyer,
				ReplyDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Buyer = result.Buyer;
				ReplyDate = result.ReplyDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
