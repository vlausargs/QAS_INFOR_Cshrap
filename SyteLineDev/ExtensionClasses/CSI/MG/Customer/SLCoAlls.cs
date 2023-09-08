//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoAlls.cs

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
	[IDOExtensionClass("SLCoAlls")]
	public class SLCoAlls : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CustServOrdersSp(string FilterVar,
		string CustNum,
		string SlsmanList,
		string OrdersFor,
		string FilterString,
		[Optional] string PSiteGroup)
		{
			var iCLM_CustServOrdersExt = new CLM_CustServOrdersFactory().Create(this, true);
			
			var result = iCLM_CustServOrdersExt.CLM_CustServOrdersSp(FilterVar,
			CustNum,
			SlsmanList,
			OrdersFor,
			FilterString,
			PSiteGroup);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustPriceIncludeTaxSp(string CustNum,
		int? CustSeq,
		ref int? CustIncludePrice,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCustPriceIncludeTaxExt = new CustPriceIncludeTaxFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCustPriceIncludeTaxExt.CustPriceIncludeTaxSp(CustNum,
				CustSeq,
				CustIncludePrice,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				CustIncludePrice = result.CustIncludePrice;
				return Severity;
			}
		}
	}
}
