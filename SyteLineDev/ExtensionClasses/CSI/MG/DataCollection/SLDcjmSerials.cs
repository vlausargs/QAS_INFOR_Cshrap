//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcjmSerials.cs

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
	[IDOExtensionClass("SLDcjmSerials")]
	public class SLDcjmSerials : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DcjmSerialLoadSp(int? GenSer,
		string SerialLike,
		int? TransNum,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site)
		{
			var iDcjmSerialLoadExt = new DcjmSerialLoadFactory().Create(this, true);
			
			var result = iDcjmSerialLoadExt.DcjmSerialLoadSp(GenSer,
			SerialLike,
			TransNum,
			Item,
			Whse,
			Loc,
			Lot,
			Site);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DcjrSerialLoadSp(byte? GenSer,
		                                  string TransType,
		                                  decimal? GenQty,
		                                  string SerialPrefix,
		                                  string SerialLike,
		                                  int? TransNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iDcjrSerialLoadExt = new DcjrSerialLoadFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iDcjrSerialLoadExt.DcjrSerialLoadSp(GenSer,
				                                                   TransType,
				                                                   GenQty,
				                                                   SerialPrefix,
				                                                   SerialLike,
				                                                   TransNum);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcjmSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcjmSerialSaveExt = new DcjmSerialSaveFactory().Create(appDb);
				
				var result = iDcjmSerialSaveExt.DcjmSerialSaveSp(TransNum,
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
		public int DcjrSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcjrSerialSaveExt = new DcjrSerialSaveFactory().Create(appDb);
				
				var result = iDcjrSerialSaveExt.DcjrSerialSaveSp(TransNum,
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
