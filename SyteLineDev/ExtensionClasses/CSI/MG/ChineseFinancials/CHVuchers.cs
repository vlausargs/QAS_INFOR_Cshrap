//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHVuchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHVuchers")]
    public class CHVuchers : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CHSVoucherPostSelectSp(string TypeCodeFrom,
                                                string TypeCodeTo,
                                                string VoucherNoFrom,
                                                string VoucherNoTo,
                                                DateTime? TransDateFrom,
                                                DateTime? TransDateTo,
                                                string UserName)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCHSVoucherPostSelectExt = new CHSVoucherPostSelectFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCHSVoucherPostSelectExt.CHSVoucherPostSelectSp(TypeCodeFrom,
                                                                               TypeCodeTo,
                                                                               VoucherNoFrom,
                                                                               VoucherNoTo,
                                                                               TransDateFrom,
                                                                               TransDateTo,
                                                                               UserName);

                return dt;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSValidateVoucherNumSP(string Prefix,
		                                   string CrntNmbr,
		                                   string TypeCode,
		                                   [Optional] DateTime? TransDate,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCHSValidateVoucherNumExt = new CHSValidateVoucherNumFactory().Create(appDb);
				
				var result = iCHSValidateVoucherNumExt.CHSValidateVoucherNumSP(Prefix,
				                                                               CrntNmbr,
				                                                               TypeCode,
				                                                               TransDate,
				                                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSCheckVoucherSp(DateTime? trans_date,
		string CrntNmbr,
		string TypeCode,
		string UserName,
		string curr_code,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSCheckVoucherExt = new CHSCheckVoucherFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSCheckVoucherExt.CHSCheckVoucherSp(trans_date,
				CrntNmbr,
				TypeCode,
				UserName,
				curr_code,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSGetVoucherTypeSp(string UserName,
		string UserGroup,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSGetVoucherTypeExt = new CHSGetVoucherTypeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSGetVoucherTypeExt.CHSGetVoucherTypeSp(UserName,
				UserGroup,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSVoucherPostSp(DateTime? trans_dateP,
		string CrntNmbr,
		string TypeCode,
		string UserName,
		[Optional] string CalledFrom,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSVoucherPostExt = new CHSVoucherPostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSVoucherPostExt.CHSVoucherPostSp(trans_dateP,
				CrntNmbr,
				TypeCode,
				UserName,
				CalledFrom,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
