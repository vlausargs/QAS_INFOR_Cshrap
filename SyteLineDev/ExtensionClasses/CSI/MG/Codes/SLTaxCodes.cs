//PROJECT NAME: CodesExt
//CLASS NAME: SLTaxcodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.Logistics.Customer;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLTaxcodes")]
    public class SLTaxcodes : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TaxCodeExistsSp(byte? TaxSystem,
                                    string TaxCodeType,
                                    string TaxCode,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTaxCodeExistsExt = new TaxCodeExistsFactory().Create(appDb);

                int Severity = iTaxCodeExistsExt.TaxCodeExistsSp(TaxSystem,
                                                                 TaxCodeType,
                                                                 TaxCode,
                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetTaxTransferVatSp(ref byte? PTransferVat,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetTaxTransferVatExt = new GetTaxTransferVatFactory().Create(appDb);

                int Severity = iGetTaxTransferVatExt.GetTaxTransferVatSp(ref PTransferVat,
                                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetTaxSystemParmSp(byte? TaxSystem,
                                      ref string TaxMode,
                                      ref byte? ActiveForPurch,
                                      ref byte? RecordZero)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetTaxSystemParmExt = new GetTaxSystemParmFactory().Create(appDb);

                int Severity = iGetTaxSystemParmExt.GetTaxSystemParmSp(TaxSystem,
                                                                       ref TaxMode,
                                                                       ref ActiveForPurch,
                                                                       ref RecordZero);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetTaxAmountSp(byte? TaxSystem,
                                  string TaxCode,
                                  string TaxCodeType,
                                  decimal? TaxBasis,
                                  string CurrCode,
                                  ref decimal? TaxAmount,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetTaxAmountExt = new GetTaxAmountFactory().Create(appDb);

                int Severity = iGetTaxAmountExt.GetTaxAmountSp(TaxSystem,
                                                               TaxCode,
                                                               TaxCodeType,
                                                               TaxBasis,
                                                               CurrCode,
                                                               ref TaxAmount,
                                                               ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxCodeValidSp(byte? TaxSystem,
		                          string TaxCode,
		                          string TaxType,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxCodeValidExt = new TaxCodeValidFactory().Create(appDb);
				
				int Severity = iTaxCodeValidExt.TaxCodeValidSp(TaxSystem,
				                                               TaxCode,
				                                               TaxType,
				                                               ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxDescSp(string PType,
		string PTaxCode1,
		string PTaxCode2,
		ref string PTaxCodeDesc1,
		ref string PTaxCodeDesc2)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxDescExt = new TaxDescFactory().Create(appDb);
				
				var result = iTaxDescExt.TaxDescSp(PType,
				PTaxCode1,
				PTaxCode2,
				PTaxCodeDesc1,
				PTaxCodeDesc2);
				
				int Severity = result.ReturnCode.Value;
				PTaxCodeDesc1 = result.PTaxCodeDesc1;
				PTaxCodeDesc2 = result.PTaxCodeDesc2;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ITaxSp(int? PTaxSystem,
		string PTaxCode,
		string PItem,
		ref string PDefaultTaxCode,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iITaxExt = new ITaxFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iITaxExt.ITaxSp(PTaxSystem,
				PTaxCode,
				PItem,
				PDefaultTaxCode,
				Site);
				
				int Severity = result.ReturnCode.Value;
				PDefaultTaxCode = result.PDefaultTaxCode;
				return Severity;
			}
		}
    }
}

