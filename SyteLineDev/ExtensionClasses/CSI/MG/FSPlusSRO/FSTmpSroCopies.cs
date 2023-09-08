//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSTmpSroCopies.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSTmpSroCopies")]
	public class FSTmpSroCopies : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSTmpSroCopyCleanupSp()
		{
			var iSSSFSTmpSroCopyCleanupExt = new SSSFSTmpSroCopyCleanupFactory().Create(this, true);
			
			var result = iSSSFSTmpSroCopyCleanupExt.SSSFSTmpSroCopyCleanupSp();
			
			
			return result??0;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSroCopyUseItem(string iTemplateSroNum,
		                                     int? iTemplateSroLine,
		                                     string iItem,
		                                     byte? ChkShowAllOper,
		                                     string iSerNum,
		                                     string Infobar,
		                                     [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSSroCopyUseItExt = new SSSFSSroCopyUseItFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSSroCopyUseItExt.SSSFSSroCopyUseItem(iTemplateSroNum,
				                                                       iTemplateSroLine,
				                                                       iItem,
				                                                       ChkShowAllOper,
				                                                       iSerNum,
				                                                       Infobar,
				                                                       FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
