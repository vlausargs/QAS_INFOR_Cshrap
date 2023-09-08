//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSTmpConts.cs

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
	[IDOExtensionClass("FSTmpConts")]
	public class FSTmpConts : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSContTmpLoadSp(string SerNum,
		string Item,
		string CustNum,
		DateTime? TestDate,
		int? InclBad,
		[Optional] string UsrNum,
		[Optional] int? CustSeq,
		[Optional] int? UsrSeq,
		[Optional] string Mode,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContTmpLoadExt = new SSSFSContTmpLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContTmpLoadExt.SSSFSContTmpLoadSp(SerNum,
				Item,
				CustNum,
				TestDate,
				InclBad,
				UsrNum,
				CustSeq,
				UsrSeq,
				Mode,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
