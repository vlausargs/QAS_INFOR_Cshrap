//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcsfcItems.cs

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
	[IDOExtensionClass("SLDcsfcItems")]
	public class SLDcsfcItems : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DcsfcItemLoadSp(int? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		[Optional] string FilterString)
		{
			var iDcsfcItemLoadExt = new DcsfcItemLoadFactory().Create(this, true);
			
			var result = iDcsfcItemLoadExt.DcsfcItemLoadSp(TransNum,
			Job,
			Suffix,
			OperNum,
			FilterString);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcsfcItemSaveSp(int? TransNum,
		string Item,
		decimal? QtyComplete,
		decimal? QtyMoved,
		decimal? QtyScrapped,
		string Reason,
		int? NextOper,
		string Location,
		string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcsfcItemSaveExt = new DcsfcItemSaveFactory().Create(appDb);
				
				var result = iDcsfcItemSaveExt.DcsfcItemSaveSp(TransNum,
				Item,
				QtyComplete,
				QtyMoved,
				QtyScrapped,
				Reason,
				NextOper,
				Location,
				Lot);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
