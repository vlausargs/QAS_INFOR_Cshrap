//PROJECT NAME: VendorExt
//CLASS NAME: SLItemPriceRequests.cs

using System;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MG;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLItemPriceRequests")]
    public class SLItemPriceRequests : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CreatePoAndOrPoitemRowSp(string PPoNum,
                                            string PVendNum,
                                            string PItem,
                                            string PVendItem,
                                            DateTime? PDueDate,
                                            string PIprId,
                                            decimal? PIprSeq,
                                            decimal? PPriceConv,
                                            decimal? PQtyConv,
                                            string PNonBaseUM,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCreatePoAndOrPoitemRowExt = new CreatePoAndOrPoitemRowFactory().Create(appDb);

                int Severity = iCreatePoAndOrPoitemRowExt.CreatePoAndOrPoitemRowSp(PPoNum,
                                                                                   PVendNum,
                                                                                   PItem,
                                                                                   PVendItem,
                                                                                   PDueDate,
                                                                                   PIprId,
                                                                                   PIprSeq,
                                                                                   PPriceConv,
                                                                                   PQtyConv,
                                                                                   PNonBaseUM,
                                                                                   ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdatePOReqLineSp(decimal? QtyConv,
		decimal? PriceConv,
		string NonBaseUM,
		string Item,
		DateTime? DueDate,
		string ReqNum,
		int? ReqLine,
		string IprId,
		decimal? IprSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdatePOReqLineExt = new UpdatePOReqLineFactory().Create(appDb);
				
				var result = iUpdatePOReqLineExt.UpdatePOReqLineSp(QtyConv,
				PriceConv,
				NonBaseUM,
				Item,
				DueDate,
				ReqNum,
				ReqLine,
				IprId,
				IprSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePoitemUMSp(string UM,
		string VendNum,
		string Item,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePoitemUMExt = new ValidatePoitemUMFactory().Create(appDb);
				
				var result = iValidatePoitemUMExt.ValidatePoitemUMSp(UM,
				VendNum,
				Item,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}