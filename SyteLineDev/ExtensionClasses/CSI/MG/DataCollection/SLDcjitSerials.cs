//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcjitSerials.cs

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
	[IDOExtensionClass("SLDcjitSerials")]
	public class SLDcjitSerials : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DcjitSerialLoadSp(int? GenSer,
		string SerialLike,
		int? TransNum,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site)
		{
			var iDcjitSerialLoadExt = new DcjitSerialLoadFactory().Create(this, true);
			
			var result = iDcjitSerialLoadExt.DcjitSerialLoadSp(GenSer,
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcjitSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcjitSerialSaveExt = new DcjitSerialSaveFactory().Create(appDb);
				
				var result = iDcjitSerialSaveExt.DcjitSerialSaveSp(TransNum,
				SerNum,
				DerSelect,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
