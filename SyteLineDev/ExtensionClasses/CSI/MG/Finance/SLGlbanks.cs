//PROJECT NAME: FinanceExt
//CLASS NAME: SLGlbanks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using CSI.Finance.Bank;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLGlbanks")]
    public class SLGlbanks : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PRGetNextCheckNumberSp(string pBankCode,
                                          ref int? rNextCheckNumber)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLGlbanksExt = new PRGetNextCheckNumberFactory().Create(appDb);

                GlCheckNumType orNextCheckNumber = rNextCheckNumber;

                int Severity = iSLGlbanksExt.PRGetNextCheckNumberSp(pBankCode,
                                                                    ref orNextCheckNumber);

                rNextCheckNumber = orNextCheckNumber;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ReturnedChecksSp(string BankCode,
                                               string Process,
                                               byte? ProcessReturnedCheck,
                                               byte? ProcessReturnedCheckDeposit)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLGlbanksExt = new CLM_ReturnedChecksFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSLGlbanksExt.CLM_ReturnedChecksSp(BankCode,
                                                                  Process,
                                                                  ProcessReturnedCheck,
                                                                  ProcessReturnedCheckDeposit);

                return dt;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_BankReconChangeSp(string pBankCode,
            DateTime? pStartTransDate,
            DateTime? pEndTransDate,
            int? pStartTransNum,
            int? pEndTransNum,
            string pTypes,
            int? pCommit,
            ref string Infobar)
        {
            var iCLM_BankReconChangeExt = new CLM_BankReconChangeFactory().Create(this, true);

            var result = iCLM_BankReconChangeExt.CLM_BankReconChangeSp(pBankCode,
                pStartTransDate,
                pEndTransDate,
                pStartTransNum,
                pEndTransNum,
                pTypes,
                pCommit,
                Infobar);

            Infobar = result.Infobar;

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int BankCompSP(string PBankCode,
		                      DateTime? PCompressDate,
		                      ref int? RNumProcessed,
		                      ref string Infobar,
		                      [Optional] int? ThruDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iBankCompExt = new CSI.Finance.BankCompFactory().Create(appDb);
				
				var result = iBankCompExt.BankCompSp(PBankCode,
				                                     PCompressDate,
				                                     RNumProcessed,
				                                     Infobar,
				                                     ThruDateOffset);
				
				int Severity = result.ReturnCode.Value;
				RNumProcessed = result.RNumProcessed;
				Infobar = result.Infobar;
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ReturnedChecksSp(string pBankCode,
		string pProcess,
		int? pProcessReturnedCheck,
		int? pProcessReturnedCheckDeposit,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iReturnedChecksExt = new ReturnedChecksFactory().Create(appDb);
				
				var result = iReturnedChecksExt.ReturnedChecksSp(pBankCode,
				pProcess,
				pProcessReturnedCheck,
				pProcessReturnedCheckDeposit,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendCustEmpNameFromRefTypeSp(string RefNum,
		string RefType,
		ref string Name,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVendCustEmpNameFromRefTypeExt = new VendCustEmpNameFromRefTypeFactory().Create(appDb);
				
				var result = iVendCustEmpNameFromRefTypeExt.VendCustEmpNameFromRefTypeSp(RefNum,
				RefType,
				Name,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Name = result.Name;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoidAPPostedPaymentDelSp(Guid? SessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoidAPPostedPaymentDelExt = new VoidAPPostedPaymentDelFactory().Create(appDb);
				
				var result = iVoidAPPostedPaymentDelExt.VoidAPPostedPaymentDelSp(SessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoidAPPostedPaymentUpdSp(Guid? SessionID,
		Guid? PRowPointer,
		int? PProcessFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoidAPPostedPaymentUpdExt = new VoidAPPostedPaymentUpdFactory().Create(appDb);
				
				var result = iVoidAPPostedPaymentUpdExt.VoidAPPostedPaymentUpdSp(SessionID,
				PRowPointer,
				PProcessFlag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoidPRPostedPaymentDelSp(Guid? SessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoidPRPostedPaymentDelExt = new VoidPRPostedPaymentDelFactory().Create(appDb);
				
				var result = iVoidPRPostedPaymentDelExt.VoidPRPostedPaymentDelSp(SessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoidPRPostedPaymentUpdSp(Guid? SessionID,
		Guid? PRowPointer,
		int? PProcessFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoidPRPostedPaymentUpdExt = new VoidPRPostedPaymentUpdFactory().Create(appDb);
				
				var result = iVoidPRPostedPaymentUpdExt.VoidPRPostedPaymentUpdSp(SessionID,
				PRowPointer,
				PProcessFlag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetTranNumForBankReconciliations(string BankReconciliationType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetTranNumForBankReconciliationsExt = new CLM_GetTranNumForBankReconciliationsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetTranNumForBankReconciliationsExt.CLM_GetTranNumForBankReconciliationsSp(BankReconciliationType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EFTFileGLBankUpSp(int? BankRecon,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEFTFileGLBankUpExt = new EFTFileGLBankUpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEFTFileGLBankUpExt.EFTFileGLBankUpSp(BankRecon,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetGLBankRowPointerSp(string BankCode,
		string ReferenceNum,
		string Type,
		ref Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetGLBankRowPointerExt = new GetGLBankRowPointerFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetGLBankRowPointerExt.GetGLBankRowPointerSp(BankCode,
				ReferenceNum,
				Type,
				RowPointer);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextCheckNumberSp(string BankCode,
		string PayType,
		ref int? NextCheckNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextCheckNumberExt = new GetNextCheckNumberFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextCheckNumberExt.GetNextCheckNumberSp(BankCode,
				PayType,
				NextCheckNumber);
				
				int Severity = result.ReturnCode.Value;
				NextCheckNumber = result.NextCheckNumber;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextReconciliationTypeNumSp(string BankCode,
		string PayType,
		ref int? NextCheckNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextReconciliationTypeNumExt = new GetNextReconciliationTypeNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextReconciliationTypeNumExt.GetNextReconciliationTypeNumSp(BankCode,
				PayType,
				NextCheckNumber);
				
				int Severity = result.ReturnCode.Value;
				NextCheckNumber = result.NextCheckNumber;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VoidAPPostedPaymentsPreSp(Guid? SessionID,
		string pBankCode,
		int? pBegCheckNum,
		int? pEndCheckNum,
		string PayType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVoidAPPostedPaymentsPreExt = new VoidAPPostedPaymentsPreFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVoidAPPostedPaymentsPreExt.VoidAPPostedPaymentsPreSp(SessionID,
				pBankCode,
				pBegCheckNum,
				pEndCheckNum,
				PayType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VoidPayUpdateSp(Guid? pRowPointer,
		string SessionIDChar,
		int? ProcessFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVoidPayUpdateExt = new VoidPayUpdateFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVoidPayUpdateExt.VoidPayUpdateSp(pRowPointer,
				SessionIDChar,
				ProcessFlag,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		/*[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VoidPRPostedPaymentSp(Guid? pRowPointer,
		Guid? SessionID,
		int? ProcessFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVoidPRPostedPaymentExt = new VoidPRPostedPaymentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVoidPRPostedPaymentExt.VoidPRPostedPaymentSp(pRowPointer,
				SessionID,
				ProcessFlag,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}*/

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VoidPRPostedPaymentSp(Guid? pRowPointer,
		Guid? SessionID,
		int? ProcessFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVoidPRPostedPaymentExt = new VoidPRPostedPaymentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVoidPRPostedPaymentExt.VoidPRPostedPaymentSp(pRowPointer,
				SessionID,
				ProcessFlag,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VoidPRPostedPaymentsPreSp(Guid? SessionID,
		string pBankCode,
		int? pBegCheckNum,
		int? pEndCheckNum,
		string pOptdfEmplType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVoidPRPostedPaymentsPreExt = new VoidPRPostedPaymentsPreFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVoidPRPostedPaymentsPreExt.VoidPRPostedPaymentsPreSp(SessionID,
				pBankCode,
				pBegCheckNum,
				pEndCheckNum,
				pOptdfEmplType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_EftOutputSp(DateTime? PEftFileDate,
		[Optional] string BankCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_EftOutputExt = new CLM_EftOutputFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_EftOutputExt.CLM_EftOutputSp(PEftFileDate,
				BankCode);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
