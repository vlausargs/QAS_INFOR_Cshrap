//PROJECT NAME: CustomerExt
//CLASS NAME: SLConInvLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLConInvLines")]
    public class SLConInvLines : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CiWorkbenchDelSp(string CustNum,
                                    short? ConInvSeq,
                                    int? InvLine,
                                    string CoNum,
                                    short? CoLine,
                                    short? CoRelease,
                                    string Regen,
                                    string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCiWorkbenchDelExt = new CiWorkbenchDelFactory().Create(appDb);

                int Severity = iCiWorkbenchDelExt.CiWorkbenchDelSp(CustNum,
                                                                   ConInvSeq,
                                                                   InvLine,
                                                                   CoNum,
                                                                   CoLine,
                                                                   CoRelease,
                                                                   Regen,
                                                                   Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PreCiGenadSp(string DoInvoice,
                                string DoNum,
                                int? DoLine,
                                short? DoSeq,
                                string CustPo,
                                string CoNum,
                                short? CoLine,
                                short? CoRelease,
                                ref byte? NewHdr,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPreCiGenadExt = new PreCiGenadFactory().Create(appDb);

                int Severity = iPreCiGenadExt.PreCiGenadSp(DoInvoice,
                                                           DoNum,
                                                           DoLine,
                                                           DoSeq,
                                                           CustPo,
                                                           CoNum,
                                                           CoLine,
                                                           CoRelease,
                                                           ref NewHdr,
                                                           ref Infobar);

                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CiGenadSp(string DoInvoice,
		string DoNum,
		int? DoLine,
		int? DoSeq,
		string CustPo,
		decimal? QtyToInvoice,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		ref int? NewHdr,
		ref string Infobar,
		[Optional] decimal? ShipmentId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCiGenadExt = new CiGenadFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCiGenadExt.CiGenadSp(DoInvoice,
				DoNum,
				DoLine,
				DoSeq,
				CustPo,
				QtyToInvoice,
				CoNum,
				CoLine,
				CoRelease,
				NewHdr,
				Infobar,
				ShipmentId);
				
				int Severity = result.ReturnCode.Value;
				NewHdr = result.NewHdr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CiGenPSp(string BeginCustomerNum,
		string EndCustomerNum,
		string InvFreq,
		int? ProcessCustOrders,
		string BeginCONum,
		string EndCONum,
		int? ProcessDelOrders,
		string BeginDONum,
		string EndDONum,
		string BeginCustPONum,
		string EndCustPONum,
		int? GenerateByShipDate,
		DateTime? ShipDate,
		int? ProcessShipments,
		decimal? BeginShipment,
		decimal? EndShipment,
		ref string Infobar,
		[Optional] string ProcessMode,
		[Optional] Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCiGenPExt = new CiGenPFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCiGenPExt.CiGenPSp(BeginCustomerNum,
				EndCustomerNum,
				InvFreq,
				ProcessCustOrders,
				BeginCONum,
				EndCONum,
				ProcessDelOrders,
				BeginDONum,
				EndDONum,
				BeginCustPONum,
				EndCustPONum,
				GenerateByShipDate,
				ShipDate,
				ProcessShipments,
				BeginShipment,
				EndShipment,
				Infobar,
				ProcessMode,
				SessionId);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
