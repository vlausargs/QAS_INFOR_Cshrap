//PROJECT NAME: APSExt
//CLASS NAME: SLEFFECTnnns.cs

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
    [IDOExtensionClass("SLEFFECTnnns")]
    public class SLEFFECTnnns : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetEFFECTSp(short? AltNo,
		                                    [Optional] string Filter)
		{
            var iCLM_ApsGetEFFECTExt = new CLM_ApsGetEFFECTFactory().Create(this, true);

            var result = iCLM_ApsGetEFFECTExt.CLM_ApsGetEFFECTSp(AltNo,
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
		public int ApsEFFECTDelSp(int? AltNo,
			Guid? RowPointer)
		{
			var iApsEFFECTDelExt = new ApsEFFECTDelFactory().Create(this, true);

			var result = iApsEFFECTDelExt.ApsEFFECTDelSp(AltNo,
				RowPointer);

			return result ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsEFFECTSaveSp(int? InsertFlag,
		int? AltNo,
		string EFFECTID,
		string DESCR,
		DateTime? STARTDATE,
		DateTime? ENDDATE,
		int? DATETYPE,
		int? CONDITION,
		string VALUE,
		string PartNo,
		string Contract)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsEFFECTSaveExt = new ApsEFFECTSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsEFFECTSaveExt.ApsEFFECTSaveSp(InsertFlag,
				AltNo,
				EFFECTID,
				DESCR,
				STARTDATE,
				ENDDATE,
				DATETYPE,
				CONDITION,
				VALUE,
				PartNo,
				Contract);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
