//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpreviews.cs

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
    [IDOExtensionClass("SLEmpreviews")]
    public class SLEmpreviews : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpReviewDateGetSp(string EmpNum,
                                      ref DateTime? EmpReviewDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpReviewDateGetExt = new EmpReviewDateGetFactory().Create(appDb);

                DateType oEmpReviewDate = EmpReviewDate;

                int Severity = iEmpReviewDateGetExt.EmpReviewDateGetSp(EmpNum,
                                                                       ref oEmpReviewDate);

                EmpReviewDate = oEmpReviewDate;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcRvwSp(string EmpNum,
		DateTime? EmpADate,
		DateTime? DatePers,
		ref DateTime? EmpReviewDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalcRvwExt = new CalcRvwFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalcRvwExt.CalcRvwSp(EmpNum,
				EmpADate,
				DatePers,
				EmpReviewDate);
				
				int Severity = result.ReturnCode.Value;
				EmpReviewDate = result.EmpReviewDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EmpReviewDateSetSp(string EmpNum,
		DateTime? EmpReviewDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEmpReviewDateSetExt = new EmpReviewDateSetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEmpReviewDateSetExt.EmpReviewDateSetSp(EmpNum,
				EmpReviewDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
