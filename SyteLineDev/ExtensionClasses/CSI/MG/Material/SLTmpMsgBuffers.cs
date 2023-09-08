//PROJECT NAME: MaterialExt
//CLASS NAME: SLTmpMsgBuffers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTmpMsgBuffers")]
    public class SLTmpMsgBuffers : ExtensionClassBase, ISLTmpMsgBuffers
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChkTempMessageBufferSp(Guid? PSessionID,
                                          ref int? Result)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iChkTempMessageBufferExt = new ChkTempMessageBufferFactory().Create(appDb);

                IntType oResult = Result;

                int Severity = iChkTempMessageBufferExt.ChkTempMessageBufferSp(PSessionID,
                                                                          ref oResult);

                Result = oResult;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteTmpMsgBufferSp(Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeleteTmpMsgBufferExt = new DeleteTmpMsgBufferFactory().Create(appDb);
				
				int Severity = iDeleteTmpMsgBufferExt.DeleteTmpMsgBufferSp(PSessionID);
				
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APVoucherPostingBackgroundMsgSp([Optional] string SessionIdChar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_APVoucherPostingBackgroundMsgExt = new Rpt_APVoucherPostingBackgroundMsgFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_APVoucherPostingBackgroundMsgExt.Rpt_APVoucherPostingBackgroundMsgSp(SessionIdChar,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARFinanceChargePostingBackgroundMsgSp([Optional] string SessionIdChar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ARFinanceChargePostingBackgroundMsgExt = new Rpt_ARFinanceChargePostingBackgroundMsgFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ARFinanceChargePostingBackgroundMsgExt.Rpt_ARFinanceChargePostingBackgroundMsgSp(SessionIdChar,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARPaymentPostingBackgroundMsgSp([Optional] string SessionIdChar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ARPaymentPostingBackgroundMsgExt = new Rpt_ARPaymentPostingBackgroundMsgFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ARPaymentPostingBackgroundMsgExt.Rpt_ARPaymentPostingBackgroundMsgSp(SessionIdChar,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InvoicePostingBackgroundMsgSp([Optional] string SessionIdChar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_InvoicePostingBackgroundMsgExt = new Rpt_InvoicePostingBackgroundMsgFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_InvoicePostingBackgroundMsgExt.Rpt_InvoicePostingBackgroundMsgSp(SessionIdChar,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
