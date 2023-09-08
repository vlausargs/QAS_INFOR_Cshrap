//PROJECT NAME: CodesExt
//CLASS NAME: SLUMConvs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.DataCollection;
using CSI.Logistics.Customer;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLUMConvs")]
    public class SLUMConvs : CSIExtensionClassBase, IExtFTSLUMConvs
    {




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UomConvAmtSp(decimal? AmtToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		ref decimal? ConvertedAmt,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var iUomConvAmtExt = new UomConvAmtFactory().Create(this);
				
				var result = iUomConvAmtExt.UomConvAmtSp(AmtToBeConverted,
				UomConvFactor,
				FROMBase,
				ConvertedAmt,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ConvertedAmt = result.ConvertedAmt;
				Infobar = result.Infobar;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int UomConvQtySp(decimal? QtyToBeConverted,
        decimal? UomConvFactor,
        string FROMBase,
        ref decimal? ConvertedQty,
        ref string Infobar)  
        {
            var iUomConvQtyExt = new UomConvQtyFactory().Create(this, true);

            var result = iUomConvQtyExt.UomConvQtySp(QtyToBeConverted,
            UomConvFactor,
            FROMBase,
            ConvertedQty,
            Infobar);

            int Severity = result.ReturnCode.Value;
            ConvertedQty = result.ConvertedQty;
            Infobar = result.Infobar;
            return Severity;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int UmCheckSp(string Selection,
		string OldUM,
		string NewUM,
		string Item,
		string ConvType,
		string CustVendType,
		decimal? ConvFactor,
		decimal? ConvDivisor,
		int? RptFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUmCheckExt = new UmCheckFactory().Create(appDb);
				
				var result = iUmCheckExt.UmCheckSp(Selection,
				OldUM,
				NewUM,
				Item,
				ConvType,
				CustVendType,
				ConvFactor,
				ConvDivisor,
				RptFlag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetumcfSp(string OtherUM,
		string Item,
		string VendNum,
		string Area,
		ref decimal? ConvFactor,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetumcfExt = new GetumcfFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetumcfExt.GetumcfSp(OtherUM,
				Item,
				VendNum,
				Area,
				ConvFactor,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				ConvFactor = result.ConvFactor;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
