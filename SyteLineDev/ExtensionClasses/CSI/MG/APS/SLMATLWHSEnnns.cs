//PROJECT NAME: APSExt
//CLASS NAME: SLMATLWHSEnnns.cs

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
    [IDOExtensionClass("SLMATLWHSEnnns")]
    public class SLMATLWHSEnnns : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetWhseMatlSp(short? AltNo,
		                                      [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetWhseMatlExt = new CLM_ApsGetWhseMatlFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetWhseMatlExt.CLM_ApsGetWhseMatlSp(AltNo,
				                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsWhseMatlDelSp(Guid? Rowp,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsWhseMatlDelExt = new ApsWhseMatlDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsWhseMatlDelExt.ApsWhseMatlDelSp(Rowp,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsWhseMatlInsSp(string MATERIALID,
		string WHSE,
		int? FLAGS,
		decimal? QUONHAND,
		decimal? SAFETYSTOCK,
		int? SRCPRIORITY,
		string SRCCUSTOMER,
		string SRCWORKCENTER,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsWhseMatlInsExt = new ApsWhseMatlInsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsWhseMatlInsExt.ApsWhseMatlInsSp(MATERIALID,
				WHSE,
				FLAGS,
				QUONHAND,
				SAFETYSTOCK,
				SRCPRIORITY,
				SRCCUSTOMER,
				SRCWORKCENTER,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsWhseMatlUpdSp(string MATERIALID,
		string WHSE,
		int? FLAGS,
		decimal? QUONHAND,
		decimal? SAFETYSTOCK,
		int? SRCPRIORITY,
		string SRCCUSTOMER,
		string SRCWORKCENTER,
		Guid? RowP,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsWhseMatlUpdExt = new ApsWhseMatlUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsWhseMatlUpdExt.ApsWhseMatlUpdSp(MATERIALID,
				WHSE,
				FLAGS,
				QUONHAND,
				SAFETYSTOCK,
				SRCPRIORITY,
				SRCCUSTOMER,
				SRCWORKCENTER,
				RowP,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
