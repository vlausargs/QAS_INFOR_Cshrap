//PROJECT NAME: CustomerExt
//CLASS NAME: SLPickListRefs.cs

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
	[IDOExtensionClass("SLPickListRefs")]
	public class SLPickListRefs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PackWorkbenchPickRefs(decimal? PickListId,
		[Optional] string FilterString)
		{
			var iCLM_PackWorkbenchPickRefsExt = new CLM_PackWorkbenchPickRefsFactory().Create(this, true);
			
			var result = iCLM_PackWorkbenchPickRefsExt.CLM_PackWorkbenchPickRefsSp(PickListId,
			FilterString);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeletePickListRefSp(decimal? PickListId,
		Guid? RefRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeletePickListRefExt = new DeletePickListRefFactory().Create(appDb);
				
				var result = iDeletePickListRefExt.DeletePickListRefSp(PickListId,
				RefRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
