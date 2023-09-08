//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPrtrxps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLPrtrxps")]
    public class SLPrtrxps : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Pr23rSp(DateTime? YearStartDate,
                                 DateTime? YearEndDate,
                                 string PIN,
                                 string EmpID,
                                 string EmpType,
                                 string EstabNumber,
                                 byte? CreateStateTaxRec,
                                 byte? pResubmit,
                                 string WFID,
                                 string OtherEIN,
                                 string Contact,
                                 string ContactPhone,
                                 string ContactPhoneExt,
                                 string ContactEmail,
                                 string ContactFax,
                                 string ContactMethod,
                                 string StateInfo1,
                                 string StateInfo2,
                                 string KindofEmployer,
                                 string EmployerContactName,
                                 string EmployerContactPhone,
                                 string EmployerContactPhoneExt,
                                 string EmployerContactEmail,
                                 string EmployerContactFax,
                                 string SubmitterLocationAddress,
                                 string SubmitterDeliveryAddress)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iPr23rExt = new Pr23rFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iPr23rExt.Pr23rSp(YearStartDate,
                                                 YearEndDate,
                                                 PIN,
                                                 EmpID,
                                                 EmpType,
                                                 EstabNumber,
                                                 CreateStateTaxRec,
                                                 pResubmit,
                                                 WFID,
                                                 OtherEIN,
                                                 Contact,
                                                 ContactPhone,
                                                 ContactPhoneExt,
                                                 ContactEmail,
                                                 ContactFax,
                                                 ContactMethod,
                                                 StateInfo1,
                                                 StateInfo2,
                                                 KindofEmployer,
                                                 EmployerContactName,
                                                 EmployerContactPhone,
                                                 EmployerContactPhoneExt,
                                                 EmployerContactEmail,
                                                 EmployerContactFax,
                                                 SubmitterLocationAddress,
                                                 SubmitterDeliveryAddress);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ScanForMissingDECodeSp(DateTime? YearStartDate,
                                          DateTime? YearEndDate,
                                          ref string PromptMsg,
                                          ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iScanForMissingDECodeExt = new ScanForMissingDECodeFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;

                int Severity = iScanForMissingDECodeExt.ScanForMissingDECodeSp(YearStartDate,
                                                                               YearEndDate,
                                                                               ref oPromptMsg,
                                                                               ref oPromptButtons);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PrcmprSp(string PText,
		                          DateTime? PBegCheckDate,
		                          DateTime? PEndCheckDate,
		                          string PBegDept,
		                          string PEndDept,
		                          ref string Infobar,
		                          [Optional] short? StartingCheckDateOffset,
		                          [Optional] short? EndingCheckDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPrcmprExt = new PrcmprFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPrcmprExt.PrcmprSp(PText,
				                                 PBegCheckDate,
				                                 PEndCheckDate,
				                                 PBegDept,
				                                 PEndDept,
				                                 Infobar,
				                                 StartingCheckDateOffset,
				                                 EndingCheckDateOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
