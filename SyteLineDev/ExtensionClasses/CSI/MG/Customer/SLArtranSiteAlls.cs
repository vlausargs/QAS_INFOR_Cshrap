//PROJECT NAME: CustomerExt
//CLASS NAME: SLArtranSiteAlls.cs

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
	[IDOExtensionClass("SLArtranSiteAlls")]
	public class SLArtranSiteAlls : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string ArsummFilter,
		[Optional] string SiteGroup,
		[Optional] string CustaddrCurrCode,
		[Optional] string Salesperson,
		[Optional] int? IncludeDirectReports)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArsummvExt = new ArsummvFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArsummvExt.ArsummvSp(PCustNum,
				PCurrentSite,
				PSubordinate,
				PActive,
				ArsummFilter,
				SiteGroup,
				CustaddrCurrCode,
				Salesperson,
				IncludeDirectReports);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
