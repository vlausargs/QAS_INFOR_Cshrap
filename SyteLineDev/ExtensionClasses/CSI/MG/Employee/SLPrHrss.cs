//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPrHrss.cs

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
    [IDOExtensionClass("SLPrHrss")]
    public class SLPrHrss : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckSickAndVacationBalSp(decimal? TransNum,
                                             string EmpNum,
                                             string HrType,
                                             decimal? Hrs,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckSickAndVacationBalExt = new CheckSickAndVacationBalFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCheckSickAndVacationBalExt.CheckSickAndVacationBalSp(TransNum,
                                                                                     EmpNum,
                                                                                     HrType,
                                                                                     Hrs,
                                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetDefaultPayRateSp(string EmpNum,
                                       string HrType,
                                       string Shift,
                                       DateTime? WorkDate,
                                       byte? CheckPrtrx,
                                       short? Seq,
                                       ref decimal? PayRate,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetDefaultPayRateExt = new GetDefaultPayRateFactory().Create(appDb);

                PayRatePreciseType oPayRate = PayRate;
                InfobarType oInfobar = Infobar;

                int Severity = iGetDefaultPayRateExt.GetDefaultPayRateSp(EmpNum,
                                                                         HrType,
                                                                         Shift,
                                                                         WorkDate,
                                                                         CheckPrtrx,
                                                                         Seq,
                                                                         ref oPayRate,
                                                                         ref oInfobar);

                PayRate = oPayRate;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int VerifyHrTypeSp(string pEmpNum,
                                  string pHrType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iVerifyHrTypeExt = new VerifyHrTypeFactory().Create(appDb);

                int Severity = iVerifyHrTypeExt.VerifyHrTypeSp(pEmpNum,
                                                               pHrType);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmployeeHoursSp(string PEmpStarting,
		string PEmpEnding,
		DateTime? PDateStarting,
		DateTime? PDateEnding,
		decimal? PTransStarting,
		decimal? PTransEnding,
		string PEmpType,
		string PPayType,
		int? PPrintCost,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_EmployeeHoursExt = new Rpt_EmployeeHoursFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_EmployeeHoursExt.Rpt_EmployeeHoursSp(PEmpStarting,
				PEmpEnding,
				PDateStarting,
				PDateEnding,
				PTransStarting,
				PTransEnding,
				PEmpType,
				PPayType,
				PPrintCost,
				PStartEmpCate,
				PEndEmpCate,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
