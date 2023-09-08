//PROJECT NAME: POSExt
//CLASS NAME: POSMMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.POS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.POS
{
    [IDOExtensionClass("POSMMatls")]
    public class POSMMatls : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSCalcQtyShippedSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          byte? LotTracked,
                                          decimal? QtyOrderedConv,
                                          ref decimal? QtyShippedConv,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSCalcQtyShippedExt = new SSSPOSCalcQtyShippedFactory().Create(appDb);

                int Severity = iSSSPOSCalcQtyShippedExt.SSSPOSCalcQtyShippedSp(Item,
                                                                               Whse,
                                                                               Loc,
                                                                               Lot,
                                                                               LotTracked,
                                                                               QtyOrderedConv,
                                                                               ref QtyShippedConv,
                                                                               ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSCreateSerialSp(string POSNum,
                                        int? TransNum,
                                        string Item,
                                        string SerNum,
                                        decimal? QtyShippedConv,
                                        byte? Selected,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSCreateSerialExt = new SSSPOSCreateSerialFactory().Create(appDb);

                int Severity = iSSSPOSCreateSerialExt.SSSPOSCreateSerialSp(POSNum,
                                                                           TransNum,
                                                                           Item,
                                                                           SerNum,
                                                                           QtyShippedConv,
                                                                           Selected,
                                                                           ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSMatlGetDiscSp(string Item,
                                       string CustNum,
                                       ref string ItemDescription,
                                       ref byte? LotTracked,
                                       ref string UM,
                                       ref byte? SerialTracked,
                                       ref decimal? DiscPct,
                                       ref string Infobar,
                                       ref string TaxCode)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSMatlGetDiscExt = new SSSPOSMatlGetDiscFactory().Create(appDb);

                int Severity = iSSSPOSMatlGetDiscExt.SSSPOSMatlGetDiscSp(Item,
                                                                         CustNum,
                                                                         ref ItemDescription,
                                                                         ref LotTracked,
                                                                         ref UM,
                                                                         ref SerialTracked,
                                                                         ref DiscPct,
                                                                         ref Infobar,
                                                                         ref TaxCode);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSPOSQtyOnHandCheckSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          byte? LotTracked,
                                          decimal? QtyShippedConv,
                                          ref byte? Valid,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSPOSQtyOnHandCheckExt = new SSSPOSQtyOnHandCheckFactory().Create(appDb);

                int Severity = iSSSPOSQtyOnHandCheckExt.SSSPOSQtyOnHandCheckSp(Item,
                                                                               Whse,
                                                                               Loc,
                                                                               Lot,
                                                                               LotTracked,
                                                                               QtyShippedConv,
                                                                               ref Valid,
                                                                               ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSPOSSerialCLSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          string POSNum,
                                          int? TransNum,
                                          decimal? QtyShipConv,
                                          string SerNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSPOSSerialCLExt = new SSSPOSSerialCLFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSPOSSerialCLExt.SSSPOSSerialCLSp(Item,
                                                                   Whse,
                                                                   Loc,
                                                                   Lot,
                                                                   POSNum,
                                                                   TransNum,
                                                                   QtyShipConv,
                                                                   SerNum);

                return dt;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSCalcRateSp(string POSNum,
		                            int? TransNum,
		                            string Item,
		                            decimal? QtyOrderedConv,
		                            byte? SSSFSYN,
		                            string BillCode,
		                            ref decimal? PriceConv,
		                            ref string Infobar,
		                            string UM,
		                            string Whse,
		                            [Optional] string CoNum,
		                            [Optional] short? CoLine,
		                            [Optional] string PromotionCode,
		                            [Optional] string site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSPOSCalcRateExt = new SSSPOSCalcRateFactory().Create(appDb);
				
				var result = iSSSPOSCalcRateExt.SSSPOSCalcRateSp(POSNum,
				                                                 TransNum,
				                                                 Item,
				                                                 QtyOrderedConv,
				                                                 SSSFSYN,
				                                                 BillCode,
				                                                 PriceConv,
				                                                 Infobar,
				                                                 UM,
				                                                 Whse,
				                                                 CoNum,
				                                                 CoLine,
				                                                 PromotionCode,
				                                                 site);
				
				int Severity = result.ReturnCode.Value;
				PriceConv = result.PriceConv;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSGetPartnerSp([Optional] string PartnerID,
		                              ref byte? OValid,
		                              ref byte? OActive,
		                              ref string OName,
		                              ref string ODept,
		                              ref string OWhse,
		                              ref string ORefType,
		                              ref string ORefNum,
		                              ref int? ORefSeq,
		                              ref string OEmail,
		                              ref string OPassword,
		                              ref string OWorkCode,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSPOSGetPartnerExt = new SSSPOSGetPartnerFactory().Create(appDb);
				
				var result = iSSSPOSGetPartnerExt.SSSPOSGetPartnerSp(PartnerID,
				                                                     OValid,
				                                                     OActive,
				                                                     OName,
				                                                     ODept,
				                                                     OWhse,
				                                                     ORefType,
				                                                     ORefNum,
				                                                     ORefSeq,
				                                                     OEmail,
				                                                     OPassword,
				                                                     OWorkCode,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				OValid = result.OValid;
				OActive = result.OActive;
				OName = result.OName;
				ODept = result.ODept;
				OWhse = result.OWhse;
				ORefType = result.ORefType;
				ORefNum = result.ORefNum;
				ORefSeq = result.ORefSeq;
				OEmail = result.OEmail;
				OPassword = result.OPassword;
				OWorkCode = result.OWorkCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSPromotionCodeValidSp([Optional] string Whse,
		                                      [Optional] string Item,
		                                      string Slsman,
		                                      string EndUserType,
		                                      [Optional] string PromotionCode,
		                                      ref string Infobar,
		                                      string CustNum,
		                                      int? CustSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSPOSPromotionCodeValidExt = new SSSPOSPromotionCodeValidFactory().Create(appDb);
				
				var result = iSSSPOSPromotionCodeValidExt.SSSPOSPromotionCodeValidSp(Whse,
				                                                                     Item,
				                                                                     Slsman,
				                                                                     EndUserType,
				                                                                     PromotionCode,
				                                                                     Infobar,
				                                                                     CustNum,
				                                                                     CustSeq);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSSerialClearSp(string POSNum,
		int? TransNum,
		string Item)
		{
			var iSSSPOSSerialClearExt = new SSSPOSSerialClearFactory().Create(this, true);

			var result = iSSSPOSSerialClearExt.SSSPOSSerialClearSp(POSNum,
				TransNum,
				Item);

			return result ?? 0;
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_POSPromotionCodeSp([Optional] string Whse,
		[Optional] string Item,
		string Slsman,
		string EndUserType,
		[Optional] string PromotionCode,
		ref string Infobar,
		string CustNum,
		int? CustSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_POSPromotionCodeExt = new CLM_POSPromotionCodeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_POSPromotionCodeExt.CLM_POSPromotionCodeSp(Whse,
				Item,
				Slsman,
				EndUserType,
				PromotionCode,
				Infobar,
				CustNum,
				CustSeq);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
