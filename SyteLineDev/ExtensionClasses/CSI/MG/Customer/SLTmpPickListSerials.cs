//PROJECT NAME: CustomerExt
//CLASS NAME: SLTmpPickListSerials.cs

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
	[IDOExtensionClass("SLTmpPickListSerials")]
	public class SLTmpPickListSerials : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateTmpPackListSerialSp(Guid? ProcessId,
		string SerNum,
		int? PickGroup,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		int? Reserved,
		string Whse,
		string Loc,
		string Lot,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGenerateTmpPackListSerialExt = new GenerateTmpPackListSerialFactory().Create(appDb);
				
				var result = iGenerateTmpPackListSerialExt.GenerateTmpPackListSerialSp(ProcessId,
				SerNum,
				PickGroup,
				CoNum,
				CoLine,
				CoRelease,
				Reserved,
				Whse,
				Loc,
				Lot,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LoadPackListSerialSp(decimal? PickListId,
		string Item,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Whse,
		string Loc,
		string Lot,
		decimal? Qty,
		string ParentContainerNum,
		int? Gen,
		decimal? GenQty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_LoadPackListSerialExt = new CLM_LoadPackListSerialFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_LoadPackListSerialExt.CLM_LoadPackListSerialSp(PickListId,
				Item,
				CoNum,
				CoLine,
				CoRelease,
				Whse,
				Loc,
				Lot,
				Qty,
				ParentContainerNum,
				Gen,
				GenQty,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
