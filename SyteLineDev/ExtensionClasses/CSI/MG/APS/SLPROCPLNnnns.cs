//PROJECT NAME: APSExt
//CLASS NAME: SLPROCPLNnnns.cs

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
	[IDOExtensionClass("SLPROCPLNnnns")]
	public class SLPROCPLNnnns : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetPROCPLNnnnsSp(short? AltNum,
		                                      [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetPROCPLNnnnsExt = new CLM_GetPROCPLNnnnsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_GetPROCPLNnnnsExt.CLM_GetPROCPLNnnnsSp(AltNum,
				                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetMATLPPSnnnsSp([Optional] string MATERIALID,
		[Optional, DefaultParameterValue(0)] int? AltNum,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetMATLPPSnnnsExt = new CLM_GetMATLPPSnnnsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetMATLPPSnnnsExt.CLM_GetMATLPPSnnnsSp(MATERIALID,
				AltNum,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcplnDelSp(string Procplan,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProcplnDelExt = new ProcplnDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProcplnDelExt.ProcplnDelSp(Procplan,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcplnInsSp(string Procplan,
		string Descr,
		string Effect,
		string SchedOnlyFg,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProcplnInsExt = new ProcplnInsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProcplnInsExt.ProcplnInsSp(Procplan,
				Descr,
				Effect,
				SchedOnlyFg,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcplnUpdSp(string Procplan,
		string Descr,
		string Effect,
		string SchedOnlyFg,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProcplnUpdExt = new ProcplnUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProcplnUpdExt.ProcplnUpdSp(Procplan,
				Descr,
				Effect,
				SchedOnlyFg,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
