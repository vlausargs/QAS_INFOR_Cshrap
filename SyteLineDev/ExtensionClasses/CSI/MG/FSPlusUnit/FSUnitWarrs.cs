//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSUnitWarrs.cs

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
	[IDOExtensionClass("FSUnitWarrs")]
	public class FSUnitWarrs : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitWarrDelSp(int? CompId,
			string WarrCode)
		{
			var iSSSFSUnitWarrDelExt = new SSSFSUnitWarrDelFactory().Create(this, true);
			
			var result = iSSSFSUnitWarrDelExt.SSSFSUnitWarrDelSp(CompId,
				WarrCode);
			
			return result??0;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSUnitConfigWarrLoadSp(int? CompId,
		DateTime? Date,
		int? MeterAmt,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitConfigWarrLoadExt = new SSSFSUnitConfigWarrLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitConfigWarrLoadExt.SSSFSUnitConfigWarrLoadSp(CompId,
				Date,
				MeterAmt,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitWarrSaveSp(int? CompId,
		string WarrCode,
		DateTime? StartDate,
		DateTime? EndDate,
		int? StartMeterAmt,
		int? EndMeterAmt,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitWarrSaveExt = new SSSFSUnitWarrSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitWarrSaveExt.SSSFSUnitWarrSaveSp(CompId,
				WarrCode,
				StartDate,
				EndDate,
				StartMeterAmt,
				EndMeterAmt,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
