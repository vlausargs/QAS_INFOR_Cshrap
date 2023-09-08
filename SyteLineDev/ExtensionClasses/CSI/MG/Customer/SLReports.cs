//PROJECT NAME: CustomerExt
//CLASS NAME: SLReports.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.MG.MGCore;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLReports")]
	public class SLReports : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetCurrentYearSP(ref int? CurYear)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                IGetSiteDateFactory getSiteDateFactory = new GetSiteDateFactory();
                var iGetCurrentYearExt = new GetCurrentYearFactory(getSiteDateFactory).Create(appDb,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);

                var result = iGetCurrentYearExt.GetCurrentYearSP(CurYear);

                CurYear = result.CurYear;

                return result.ReturnCode.Value;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int GetReportLabelsSp(string RepID,
		                             string RepType,
		                             short? Line,
		                             [Optional] ref string Label1,
		                             [Optional] ref string Label2,
		                             [Optional] ref string Label3)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetReportLabelsExt = new GetReportLabelsFactory().Create(appDb);
				
				var result = iGetReportLabelsExt.GetReportLabelsSp(RepID,
				                                                   RepType,
				                                                   Line,
				                                                   Label1,
				                                                   Label2,
				                                                   Label3);
				
				int Severity = result.ReturnCode.Value;
				Label1 = result.Label1;
				Label2 = result.Label2;
				Label3 = result.Label3;
				return Severity;
			}
		}
	}
}
