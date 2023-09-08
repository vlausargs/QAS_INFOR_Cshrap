//PROJECT NAME: FinanceExt
//CLASS NAME: SLFadeptabs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFadeptabs")]
    public class SLFadeptabs : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DeprMethodSp()
		{
			var iCLM_DeprMethodExt = this.GetService<ICLM_DeprMethod>();

			var result = iCLM_DeprMethodExt.CLM_DeprMethodSp();

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeprMethodValidateSp(ref string Method,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeprMethodValidateExt = new DeprMethodValidateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeprMethodValidateExt.DeprMethodValidateSp(Method,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Method = result.Method;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}

