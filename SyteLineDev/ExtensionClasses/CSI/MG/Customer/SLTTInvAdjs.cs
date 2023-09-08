//PROJECT NAME: CustomerExt
//CLASS NAME: SLTTInvAdjs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.DataCollection;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLTTInvAdjs")]
	public class SLTTInvAdjs : CSIExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvAdjCheckSp(string CoNum,
		                         decimal? UserId,
		                         Guid? SessionID,
		                         ref string Infobar,
		                         [Optional, DefaultParameterValue(0)] decimal? Freight,
		[Optional, DefaultParameterValue(0)] decimal? MiscCharges)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInvAdjCheckExt = new InvAdjCheckFactory().Create(appDb);
				
				var result = iInvAdjCheckExt.InvAdjCheckSp(CoNum,
				                                           UserId,
				                                           SessionID,
				                                           Infobar,
				                                           Freight,
				                                           MiscCharges);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UomConvAmtSp(decimal? AmtToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		ref decimal? ConvertedAmt,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
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
		public int InvAdjClearSp(string CoNum,
		decimal? UserId,
		Guid? SessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvAdjClearExt = new InvAdjClearFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvAdjClearExt.InvAdjClearSp(CoNum,
				UserId,
				SessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvAdjUpdateSp(Guid? PRowPointer,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		decimal? PQtyAdj,
		decimal? PNewDisc,
		decimal? PNewPrice,
		decimal? PNewPriceConv,
		decimal? PNewQtyConv,
		decimal? PNewLineNet,
		decimal? PNetAdjust,
		string PTransNat,
		string PTransNatDesc,
		string PTransNat2,
		string PTransNat2Desc,
		string POrigInvNum,
		string PReasonText,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvAdjUpdateExt = new InvAdjUpdateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvAdjUpdateExt.InvAdjUpdateSp(PRowPointer,
				PCoNum,
				PCoLine,
				PCoRelease,
				PQtyAdj,
				PNewDisc,
				PNewPrice,
				PNewPriceConv,
				PNewQtyConv,
				PNewLineNet,
				PNetAdjust,
				PTransNat,
				PTransNatDesc,
				PTransNat2,
				PTransNat2Desc,
				POrigInvNum,
				PReasonText,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InvAdjLoadSp(string PrevCoNum,
		string PCoNum,
		string PApplyToInvNum,
		decimal? UserId,
		[Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_InvAdjLoadExt = new CLM_InvAdjLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_InvAdjLoadExt.CLM_InvAdjLoadSp(PrevCoNum,
				PCoNum,
				PApplyToInvNum,
				UserId,
				Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
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
