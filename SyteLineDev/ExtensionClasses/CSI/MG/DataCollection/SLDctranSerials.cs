//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDctranSerials.cs

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
	[IDOExtensionClass("SLDctranSerials")]
	public class SLDctranSerials : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DctrSerialLoadSp(byte? GenSer,
		                                  string TransType,
		                                  decimal? GenQty,
		                                  string SerialPrefix,
		                                  int? TransNum,
		                                  decimal? QtyReceived,
		                                  string FromLot,
		                                  string ToLoc,
		                                  string ToLot,
		                                  string TrnNum,
		                                  short? TrnLine,
		                                  string StartSerNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iDctrSerialLoadExt = new DctrSerialLoadFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iDctrSerialLoadExt.DctrSerialLoadSp(GenSer,
				                                                   TransType,
				                                                   GenQty,
				                                                   SerialPrefix,
				                                                   TransNum,
				                                                   QtyReceived,
				                                                   FromLot,
				                                                   ToLoc,
				                                                   ToLot,
				                                                   TrnNum,
				                                                   TrnLine,
				                                                   StartSerNum);
				
				return dt;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DctsSerialLoadSp(byte? GenSer,
		                                  int? TransNum,
		                                  decimal? QtyShipped,
		                                  string FromLoc,
		                                  string FromLot,
		                                  string ToLot,
		                                  string TrnNum,
		                                  short? TrnLine,
		                                  string StartSerNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iDctsSerialLoadExt = new DctsSerialLoadFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iDctsSerialLoadExt.DctsSerialLoadSp(GenSer,
				                                                   TransNum,
				                                                   QtyShipped,
				                                                   FromLoc,
				                                                   FromLot,
				                                                   ToLot,
				                                                   TrnNum,
				                                                   TrnLine,
				                                                   StartSerNum);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DctrSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDctrSerialSaveExt = new DctrSerialSaveFactory().Create(appDb);
				
				var result = iDctrSerialSaveExt.DctrSerialSaveSp(TransNum,
				SerNum,
				DerSelect,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DctsSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDctsSerialSaveExt = new DctsSerialSaveFactory().Create(appDb);
				
				var result = iDctsSerialSaveExt.DctsSerialSaveSp(TransNum,
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
