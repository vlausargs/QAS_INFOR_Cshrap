//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcsfcSerials.cs

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
	[IDOExtensionClass("SLDcsfcSerials")]
	public class SLDcsfcSerials : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DcsfcSerialLoadSp(int? GenSer,
		decimal? GenQty,
		string SerialLike,
		int? TransNum,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site)
		{
			var iDcsfcSerialLoadExt = new DcsfcSerialLoadFactory().Create(this, true);
			
			var result = iDcsfcSerialLoadExt.DcsfcSerialLoadSp(GenSer,
			GenQty,
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
		public int DcsfcSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcsfcSerialSaveExt = new DcsfcSerialSaveFactory().Create(appDb);
				
				var result = iDcsfcSerialSaveExt.DcsfcSerialSaveSp(TransNum,
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
