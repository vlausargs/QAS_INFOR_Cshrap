//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcmoveSerials.cs

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
	[IDOExtensionClass("SLDcmoveSerials")]
	public class SLDcmoveSerials : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DcmoveSerialLoadSp(int? GenSer,
		string SerialLike,
		int? TransNum,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site)
		{
			var iDcmoveSerialLoadExt = new DcmoveSerialLoadFactory().Create(this, true);
			
			var result = iDcmoveSerialLoadExt.DcmoveSerialLoadSp(GenSer,
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
		public int DcmoveSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcmoveSerialSaveExt = new DcmoveSerialSaveFactory().Create(appDb);
				
				var result = iDcmoveSerialSaveExt.DcmoveSerialSaveSp(TransNum,
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
