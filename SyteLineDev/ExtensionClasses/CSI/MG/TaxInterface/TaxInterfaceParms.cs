//PROJECT NAME: TaxInterfaceExt
//CLASS NAME: TaxInterfaceParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.TaxInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.TaxInterface
{
    [IDOExtensionClass("TaxInterfaceParms")]
    public class TaxInterfaceParms : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSVTXTXWOpenCloseSp(byte? ProcessFlag,
                                        ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSVTXTXWOpenCloseExt = new SSSVTXTXWOpenCloseFactory().Create(appDb);

                InfobarType oInfoBar = InfoBar;

                int Severity = iSSSVTXTXWOpenCloseExt.SSSVTXTXWOpenCloseSp(ProcessFlag,
                                                                           ref oInfoBar);

                InfoBar = oInfoBar;

                return Severity;
            }
        }
        
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSVTXCalcCoTaxSp(string pCoNum,
			ref string Infobar)
		{
			var iSSSVTXCalcCoTaxExt = new SSSVTXCalcCoTaxFactory().Create(this, true);
			
			var result = iSSSVTXCalcCoTaxExt.SSSVTXCalcCoTaxSp(pCoNum,
				Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSVTXCustIntlTaxCodeDefaultSp(string Country,
		ref string TaxCode1)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSVTXCustIntlTaxCodeDefaultExt = new SSSVTXCustIntlTaxCodeDefaultFactory().Create(appDb);
				
				var result = iSSSVTXCustIntlTaxCodeDefaultExt.SSSVTXCustIntlTaxCodeDefaultSp(Country,
				TaxCode1);
				
				int Severity = result.ReturnCode.Value;
				TaxCode1 = result.TaxCode1;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSVTXSetCustTaxCode1Sp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSVTXSetCustTaxCode1Ext = new SSSVTXSetCustTaxCode1Factory().Create(appDb);
				
				var result = iSSSVTXSetCustTaxCode1Ext.SSSVTXSetCustTaxCode1Sp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSVTXValidateAddressSp(int? iUpdateRecord,
		string iCustNum,
		int? iCustSeq,
		ref string ioGeo,
		ref string iState,
		ref string iCity,
		ref string iZip,
		ref string iCnty,
		ref string iCountry,
		ref string iAddr1,
		ref string iAddr2,
		ref string iAddr3,
		ref string iAddr4,
		ref int? oValid,
		string iAddressType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSVTXValidateAddressExt = new SSSVTXValidateAddressFactory().Create(appDb);
				
				var result = iSSSVTXValidateAddressExt.SSSVTXValidateAddressSp(iUpdateRecord,
				iCustNum,
				iCustSeq,
				ioGeo,
				iState,
				iCity,
				iZip,
				iCnty,
				iCountry,
				iAddr1,
				iAddr2,
				iAddr3,
				iAddr4,
				oValid,
				iAddressType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ioGeo = result.ioGeo;
				iState = result.iState;
				iCity = result.iCity;
				iZip = result.iZip;
				iCnty = result.iCnty;
				iCountry = result.iCountry;
				iAddr1 = result.iAddr1;
				iAddr2 = result.iAddr2;
				iAddr3 = result.iAddr3;
				iAddr4 = result.iAddr4;
				oValid = result.oValid;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSVTXEncryptPasswordWrapSp(string Password,
		ref string EncryptedPassword,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSVTXEncryptPasswordWrapExt = new SSSVTXEncryptPasswordWrapFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSVTXEncryptPasswordWrapExt.SSSVTXEncryptPasswordWrapSp(Password,
				EncryptedPassword,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				EncryptedPassword = result.EncryptedPassword;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
