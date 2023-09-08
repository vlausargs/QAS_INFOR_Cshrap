//PROJECT NAME: APSExt
//CLASS NAME: SLLOOKUP000s.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLLOOKUP000s")]
    public class SLLOOKUP000s : ExtensionClassBase
    {




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetLOOKUPSp(short? AltNo,
		                                    [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetLOOKUPExt = new CLM_ApsGetLOOKUPFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetLOOKUPExt.CLM_ApsGetLOOKUPSp(AltNo,
				                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AddLookupHdrSp(string Tabid,
		string MatrixType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAddLookupHdrExt = new AddLookupHdrFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAddLookupHdrExt.AddLookupHdrSp(Tabid,
				MatrixType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DelLookupHdrSp(string Tabid,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDelLookupHdrExt = new DelLookupHdrFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDelLookupHdrExt.DelLookupHdrSp(Tabid,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LOOKUPDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLOOKUPDelExt = new LOOKUPDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLOOKUPDelExt.LOOKUPDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LOOKUPSaveSp(int? InsertFlag,
		int? AltNo,
		string TABID,
		string INDEX1,
		string INDEX2,
		decimal? VAL)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLOOKUPSaveExt = new LOOKUPSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLOOKUPSaveExt.LOOKUPSaveSp(InsertFlag,
				AltNo,
				TABID,
				INDEX1,
				INDEX2,
				VAL);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
