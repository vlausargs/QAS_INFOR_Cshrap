//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipMethods.cs

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
	[IDOExtensionClass("SLShipMethods")]
	public class SLShipMethods : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetPortalCoShippingMethodsSp(string CoNum,
		string CoPaymentMethod,
		int? LocaleID,
		string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetPortalCoShippingMethodsExt = new CLM_GetPortalCoShippingMethodsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetPortalCoShippingMethodsExt.CLM_GetPortalCoShippingMethodsSp(CoNum,
				CoPaymentMethod,
				LocaleID,
				Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
