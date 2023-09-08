//PROJECT NAME: APSExt
//CLASS NAME: SLJOBSTEPnnns.cs

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
    [IDOExtensionClass("SLJOBSTEPnnns")]
    public class SLJOBSTEPnnns : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetJOBSTEPSp(short? AltNo,
		                                     [Optional] string Filter,
		                                     [Optional] string PROCPLANID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetJOBSTEPExt = new CLM_ApsGetJOBSTEPFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetJOBSTEPExt.CLM_ApsGetJOBSTEPSp(AltNo,
				                                                       Filter,
				                                                       PROCPLANID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsJOBSTEPDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsJOBSTEPDelExt = new ApsJOBSTEPDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsJOBSTEPDelExt.ApsJOBSTEPDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsJOBSTEPSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string WORKCENTER,
		string JSID,
		string DESCR,
		string STEPEXP,
		int? STEPEXPRL,
		string RESACTN1,
		string RESACTN2,
		string RESACTN3,
		string RESACTN4,
		string RESACTN5,
		string RESACTN6,
		string RESID1,
		string RESID2,
		string RESID3,
		string RESID4,
		string RESID5,
		string RESID6,
		int? RESNMBR1,
		int? RESNMBR2,
		int? RESNMBR3,
		int? RESNMBR4,
		int? RESNMBR5,
		int? RESNMBR6,
		decimal? STEPTIME,
		int? STEPTMRL,
		DateTime? EFFDATE,
		DateTime? OBSDATE,
		string RGID,
		string TABID,
		int? WHENRL,
		string BASEDCD,
		decimal? SETUPTIME,
		string STIMEXP,
		int? STIMEXPRL,
		decimal? MOVETIME,
		decimal? QTIME,
		decimal? COOLTIME,
		int? CRSBRKRL,
		int? OLTYPE,
		decimal? OLVALUE,
		decimal? SPLITSIZE,
		string BATCHDEF,
		int? SPLITRULE,
		string SPLITGROUP)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsJOBSTEPSaveExt = new ApsJOBSTEPSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsJOBSTEPSaveExt.ApsJOBSTEPSaveSp(InsertFlag,
				AltNo,
				PROCPLANID,
				WORKCENTER,
				JSID,
				DESCR,
				STEPEXP,
				STEPEXPRL,
				RESACTN1,
				RESACTN2,
				RESACTN3,
				RESACTN4,
				RESACTN5,
				RESACTN6,
				RESID1,
				RESID2,
				RESID3,
				RESID4,
				RESID5,
				RESID6,
				RESNMBR1,
				RESNMBR2,
				RESNMBR3,
				RESNMBR4,
				RESNMBR5,
				RESNMBR6,
				STEPTIME,
				STEPTMRL,
				EFFDATE,
				OBSDATE,
				RGID,
				TABID,
				WHENRL,
				BASEDCD,
				SETUPTIME,
				STIMEXP,
				STIMEXPRL,
				MOVETIME,
				QTIME,
				COOLTIME,
				CRSBRKRL,
				OLTYPE,
				OLVALUE,
				SPLITSIZE,
				BATCHDEF,
				SPLITRULE,
				SPLITGROUP);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
