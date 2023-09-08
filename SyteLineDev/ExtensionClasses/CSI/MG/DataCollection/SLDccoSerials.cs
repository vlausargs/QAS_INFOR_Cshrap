//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDccoSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.DataCollection;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DataCollection
{
	[IDOExtensionClass("SLDccoSerials")]
	public class SLDccoSerials : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DccoSerialLoadSp(byte? GenSer,
		                                  string StartSerNum,
		                                  int? TransNum,
		                                  string Item,
		                                  string Whse,
		                                  string Loc,
		                                  string Lot,
		                                  decimal? QtyShipped,
		                                  decimal? QtyReturned,
		                                  string CoNum,
		                                  short? CoLine,
		                                  short? CoRelease)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iDccoSerialLoadExt = new DccoSerialLoadFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iDccoSerialLoadExt.DccoSerialLoadSp(GenSer,
				                                                   StartSerNum,
				                                                   TransNum,
				                                                   Item,
				                                                   Whse,
				                                                   Loc,
				                                                   Lot,
				                                                   QtyShipped,
				                                                   QtyReturned,
				                                                   CoNum,
				                                                   CoLine,
				                                                   CoRelease);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DccoSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDccoSerialSaveExt = new DccoSerialSaveFactory().Create(appDb);
				
				var result = iDccoSerialSaveExt.DccoSerialSaveSp(TransNum,
				SerNum,
				DerSelect,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
