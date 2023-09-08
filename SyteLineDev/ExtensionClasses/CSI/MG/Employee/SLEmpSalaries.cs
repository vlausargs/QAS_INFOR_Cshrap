//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpSalaries.cs

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
    [IDOExtensionClass("SLEmpSalaries")]
    public class SLEmpSalaries : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckNewSalarySp(string EmpSalaryEmpNum,
                                    decimal? EmpSalaryNewSalary,
                                    string EmpSalaryOldSalPeriod)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckNewSalaryExt = new CheckNewSalaryFactory().Create(appDb);

                int Severity = iCheckNewSalaryExt.CheckNewSalarySp(EmpSalaryEmpNum,
                                                                   EmpSalaryNewSalary,
                                                                   EmpSalaryOldSalPeriod);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmployeeSalaryPeriodSp(string JobId,
                                          ref string SalaryPeriod,
                                          ref string PayFreq)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmployeeSalaryPeriodExt = new EmployeeSalaryPeriodFactory().Create(appDb);

                SalPeriodType oSalaryPeriod = SalaryPeriod;
                PrPayFreqType oPayFreq = PayFreq;

                int Severity = iEmployeeSalaryPeriodExt.EmployeeSalaryPeriodSp(JobId,
                                                                               ref oSalaryPeriod,
                                                                               ref oPayFreq);

                SalaryPeriod = oSalaryPeriod;
                PayFreq = oPayFreq;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int EmpSalaryDeleteSp(string EmpSalaryEmpNum,
			DateTime? EmpSalaryJobdate,
			DateTime? EmpSalarySalDate,
			ref string Infobar)
		{
			var iEmpSalaryDeleteExt = new EmpSalaryDeleteFactory().Create(this, true);

			var result = iEmpSalaryDeleteExt.EmpSalaryDeleteSp(EmpSalaryEmpNum,
				EmpSalaryJobdate,
				EmpSalarySalDate,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SalUpdSp(string ProcSel,
		                          string StartDept,
		                          string EndDept,
		                          string StartEmp,
		                          string EndEmp,
		                          DateTime? StartEffDate,
		                          DateTime? EndEffDate,
		                          ref string Infobar,
		                          [Optional] short? StartEffDateOffset,
		                          [Optional] short? EndEffDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSalUpdExt = new SalUpdFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSalUpdExt.SalUpdSp(ProcSel,
				                                 StartDept,
				                                 EndDept,
				                                 StartEmp,
				                                 EndEmp,
				                                 StartEffDate,
				                                 EndEffDate,
				                                 Infobar,
				                                 StartEffDateOffset,
				                                 EndEffDateOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSalISp(string PEmpNum,
			DateTime? PSalDate,
			DateTime? PJobDate,
			decimal? PSalary,
			string PSalaryPeriod,
			string PReasonCode,
			string PPayFreq,
			ref string Infobar,
			[Optional, DefaultParameterValue(0)] int? PFlageCheckReasonCode)
		{
			var iSSalIExt = new SSalIFactory().Create(this, true);
			
			var result = iSSalIExt.SSalISp(PEmpNum,
				PSalDate,
				PJobDate,
				PSalary,
				PSalaryPeriod,
				PReasonCode,
				PPayFreq,
				Infobar,
				PFlageCheckReasonCode);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

    }
}
