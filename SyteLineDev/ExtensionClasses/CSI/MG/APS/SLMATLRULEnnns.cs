//PROJECT NAME: APSExt
//CLASS NAME: SLMATLRULEnnns.cs

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
    [IDOExtensionClass("SLMATLRULEnnns")]
    public class SLMATLRULEnnns : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLRULESp(short? AltNo,
		                                      [Optional] string Filter)
		{
            var iCLM_ApsGetMATLRULEExt = new CLM_ApsGetMATLRULEFactory().Create(this, true);

            var result = iCLM_ApsGetMATLRULEExt.CLM_ApsGetMATLRULESp(AltNo,
                Filter);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLRULEDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMATLRULEDelExt = new ApsMATLRULEDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMATLRULEDelExt.ApsMATLRULEDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLRULESaveSp(int? InsertFlag,
		int? AltNo,
		string LMATLID,
		string RSITEID,
		string EFFECTID,
		string RMATLID,
		decimal? FLEADTIME,
		decimal? VLEADTIME,
		decimal? TRANSIT,
		int? TIMEOUT,
		decimal? UOMSCALE)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMATLRULESaveExt = new ApsMATLRULESaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMATLRULESaveExt.ApsMATLRULESaveSp(InsertFlag,
				AltNo,
				LMATLID,
				RSITEID,
				EFFECTID,
				RMATLID,
				FLEADTIME,
				VLEADTIME,
				TRANSIT,
				TIMEOUT,
				UOMSCALE);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
