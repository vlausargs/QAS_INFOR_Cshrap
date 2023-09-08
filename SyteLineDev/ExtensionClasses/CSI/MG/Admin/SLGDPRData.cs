//PROJECT NAME: AdminExt
//CLASS NAME: SLGDPRData.cs

using CSI.Admin;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Reporting.Admin;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLGDPRData")]
    public class SLGDPRData : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int XOutGDPRDataSP(Guid? ProcessId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iXOutGDPRDataExt = new XOutGDPRDataFactory().Create(appDb);

                int Severity = iXOutGDPRDataExt.XOutGDPRDataSP(ProcessId);

                return Severity;
            }
        }
       
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_ConsumerPrivacySp(Guid? SessionID,
                                               string pSite)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iRpt_ConsumerPrivacyExt = new Rpt_ConsumerPrivacyFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iRpt_ConsumerPrivacyExt.Rpt_ConsumerPrivacySp(SessionID,
                                                                             pSite);

                return dt;
            }
        }
        
        
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteGDPRDataSP(Guid? ProcessId)
		{
			var iDeleteGDPRDataExt = new DeleteGDPRDataFactory().Create(this, true);
			
			var result = iDeleteGDPRDataExt.DeleteGDPRDataSP(ProcessId);
			
			return result??0;
		}

        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GDPRDataSP(Guid? ProcessId,
		string Name,
		string Country,
		string DataGroupList)
		{
			var iCLM_GDPRDataExt = new CLM_GDPRDataFactory().Create(this, true);
			
			var result = iCLM_GDPRDataExt.CLM_GDPRDataSP(ProcessId,
			Name,
			Country,
			DataGroupList);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreatePrivacyUtilityEsigSp(Guid? TmpGDPRDataRowpointer,
		string ProcessType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreatePrivacyUtilityEsigExt = new CreatePrivacyUtilityEsigFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreatePrivacyUtilityEsigExt.CreatePrivacyUtilityEsigSp(TmpGDPRDataRowpointer,
				ProcessType);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ApplicantPrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ApplicantPrivacyExt = new CSI.Admin.Rpt_ApplicantPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ApplicantPrivacyExt.Rpt_ApplicantPrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AppRefPrivacySp(string ApplicantNum, string pSite)
		{
			var iRpt_AppRefPrivacyExt = new Rpt_AppRefPrivacyFactory().Create(this, true);

			var result = iRpt_AppRefPrivacyExt.Rpt_AppRefPrivacySp(ApplicantNum, pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CreditCardPrivacySp(string CustNum,
			int? CustSeq,
			string pSite)
		{
			var iRpt_CreditCardPrivacyExt = new Rpt_CreditCardPrivacyFactory().Create(this, true);

			var result = iRpt_CreditCardPrivacyExt.Rpt_CreditCardPrivacySp(CustNum,
				CustSeq,
				pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerPrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CustomerPrivacyExt = new CSI.Admin.Rpt_CustomerPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CustomerPrivacyExt.Rpt_CustomerPrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DropShipToPrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_DropShipToPrivacyExt = new CSI.Admin.Rpt_DropShipToPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_DropShipToPrivacyExt.Rpt_DropShipToPrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpChildPrivacySp(string EmpNum,
			string pSite)
		{
			var iRpt_EmpChildPrivacyExt = this.GetService<IRpt_EmpChildPrivacy>();

			var result = iRpt_EmpChildPrivacyExt.Rpt_EmpChildPrivacySp(EmpNum,
				pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpContactPrivacySp(string EmpNum, string pSite)
		{
			var iRpt_EmpContactPrivacyExt = new Rpt_EmpContactPrivacyFactory().Create(this, true);

			var result = iRpt_EmpContactPrivacyExt.Rpt_EmpContactPrivacySp(EmpNum, pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpEducationPrivacySp([Optional] string ApplicantNum,
			[Optional] string EmpNum,
			[Optional] string pSite)
		{
			var iRpt_EmpEducationPrivacyExt = new Rpt_EmpEducationPrivacyFactory().Create(this, true);

			var result = iRpt_EmpEducationPrivacyExt.Rpt_EmpEducationPrivacySp(ApplicantNum,
				EmpNum,
				pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpExpPrivacySp([Optional] string ApplicantNum,
			[Optional] string EmpNum,
			[Optional] string pSite)
		{
			var iRpt_EmpExpPrivacyExt = new Rpt_EmpExpPrivacyFactory().Create(this, true);

			var result = iRpt_EmpExpPrivacyExt.Rpt_EmpExpPrivacySp(ApplicantNum,
				EmpNum,
				pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpInjuryPrivacySp(string EmpNum, string pSite)
		{
			var iRpt_EmpInjuryPrivacyExt = new Rpt_EmpInjuryPrivacyFactory().Create(this, true);

			var result = iRpt_EmpInjuryPrivacyExt.Rpt_EmpInjuryPrivacySp(EmpNum, pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpInsurancePrivacySp(string EmpNum, string pSite)
		{
			var iRpt_EmpInsurancePrivacyExt = new Rpt_EmpInsurancePrivacyFactory().Create(this, true);

			var result = iRpt_EmpInsurancePrivacyExt.Rpt_EmpInsurancePrivacySp(EmpNum, pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmployeePrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_EmployeePrivacyExt = new CSI.Admin.Rpt_EmployeePrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_EmployeePrivacyExt.Rpt_EmployeePrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmpPrBankPrivacySp(string EmpNum, string pSite)
		{
			var iRpt_EmpPrBankPrivacyExt = new Rpt_EmpPrBankPrivacyFactory().Create(this, true);

			var result = iRpt_EmpPrBankPrivacyExt.Rpt_EmpPrBankPrivacySp(EmpNum, pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PartnerPrivacySp(string RefNum,
			int? RefSeq,
			string RefType,
			string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PartnerPrivacyExt = new Rpt_PartnerPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PartnerPrivacyExt.Rpt_PartnerPrivacySp(RefNum,
				RefSeq,
				RefType,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PointOfSalesPrivacySp(string CustNum,
			int? CustSeq,
			string pSite)
		{
			var iRpt_PointOfSalesPrivacyExt = new Rpt_PointOfSalesPrivacyFactory().Create(this, true);
			
			var result = iRpt_PointOfSalesPrivacyExt.Rpt_PointOfSalesPrivacySp(CustNum,
				CustSeq,
				pSite);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProspectPrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProspectPrivacyExt = new CSI.Admin.Rpt_ProspectPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProspectPrivacyExt.Rpt_ProspectPrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalesContactPrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalesContactPrivacyExt = new Rpt_SalesContactPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalesContactPrivacyExt.Rpt_SalesContactPrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ServiceContactPrivacySp(string CustNum,
			int? CustSeq,
			string pSite)
		{
			var iRpt_ServiceContactPrivacyExt = new Rpt_ServiceContactPrivacyFactory().Create(this, true);
			
			var result = iRpt_ServiceContactPrivacyExt.Rpt_ServiceContactPrivacySp(CustNum,
				CustSeq,
				pSite);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ServiceContractPrivacySp(string CustNum,
			int? CustSeq,
			string pSite)
		{
			var iRpt_ServiceContractPrivacyExt = new Rpt_ServiceContractPrivacyFactory().Create(this, true);
			
			var result = iRpt_ServiceContractPrivacyExt.Rpt_ServiceContractPrivacySp(CustNum,
				CustSeq,
				pSite);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VendorPrivacySp(Guid? SessionID,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VendorPrivacyExt = new Rpt_VendorPrivacyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VendorPrivacyExt.Rpt_VendorPrivacySp(SessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}

