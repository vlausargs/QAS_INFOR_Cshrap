//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoSlsComms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLCoSlsComms")]
	public class SLCoSlsComms : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCommBaseSp(string CoNum,
		                         short? CoLine,
		                         ref decimal? CommBase)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetCommBaseExt = new GetCommBaseFactory().Create(appDb);
				
				int Severity = iGetCommBaseExt.GetCommBaseSp(CoNum,
				                                             CoLine,
				                                             ref CommBase);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateCoLineSp(string CoNum,
			int? CoLine,
			ref string Infobar)
        {
            var iValidateCoLineExt = new ValidateCoLineFactory().Create(this, true);

            var result = iValidateCoLineExt.ValidateCoLineSp(CoNum,
				CoLine,
				Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }
    }
}
