//PROJECT NAME: APSExt
//CLASS NAME: SLWHSEnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLWHSEnnns")]
    public class SLWHSEnnns : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetWhseSp(short? AltNo,
		                                  [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetWhseExt = new CLM_ApsGetWhseFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetWhseExt.CLM_ApsGetWhseSp(AltNo,
				                                                 FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsWhseDelSp(Guid? Rowp,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsWhseDelExt = new ApsWhseDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsWhseDelExt.ApsWhseDelSp(Rowp,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsWhseInsSp(string WHSE,
		int? derPLANINTRASITETRANSFERS,
		decimal? TRNTIME,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsWhseInsExt = new ApsWhseInsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsWhseInsExt.ApsWhseInsSp(WHSE,
				derPLANINTRASITETRANSFERS,
				TRNTIME,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsWhseUpdSp(string WHSE,
		int? derPLANINTRASITETRANSFERS,
		decimal? TRNTIME,
		Guid? RowP,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsWhseUpdExt = new ApsWhseUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsWhseUpdExt.ApsWhseUpdSp(WHSE,
				derPLANINTRASITETRANSFERS,
				TRNTIME,
				RowP,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
