//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSConInvHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSConInvHdrs")]
	public class FSConInvHdrs : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSProfileConInvoicingSp([Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] string StartContNum,
		[Optional] string EndContNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSProfileConInvoicingExt = new SSSFSProfileConInvoicingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSProfileConInvoicingExt.SSSFSProfileConInvoicingSp(StartInvNum,
				EndInvNum,
				StartContNum,
				EndContNum,
				StartInvDate,
				EndInvDate,
				StartCustNum,
				EndCustNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSProfileSROInvoicingSp([Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] string StartOrdNum,
		[Optional] string EndOrdNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSProfileSROInvoicingExt = new SSSFSProfileSROInvoicingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSProfileSROInvoicingExt.SSSFSProfileSROInvoicingSp(StartInvNum,
				EndInvNum,
				StartOrdNum,
				EndOrdNum,
				StartInvDate,
				EndInvDate,
				StartCustNum,
				EndCustNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
