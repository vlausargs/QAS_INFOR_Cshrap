//PROJECT NAME: APSExt
//CLASS NAME: SLBOMnnns.cs

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
    [IDOExtensionClass("SLBOMnnns")]
    public class SLBOMnnns : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetBOMSp(short? AltNo,
		                                 [Optional] string Filter)
		{
            var iCLM_ApsGetBOMExt = new CLM_ApsGetBOMFactory().Create(this, true);

            var result = iCLM_ApsGetBOMExt.CLM_ApsGetBOMSp(AltNo,
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
		public int ApsBOMDelSp(int? AltNo,
			Guid? RowPointer)
		{
			var iApsBOMDelExt = new ApsBOMDelFactory().Create(this, true);

			var result = iApsBOMDelExt.ApsBOMDelSp(AltNo,
				RowPointer);

			return result ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBOMSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string JSID,
		string MATERIALID,
		string QUANCD,
		decimal? QUANTITY,
		DateTime? EFFDATE,
		DateTime? OBSDATE)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsBOMSaveExt = new ApsBOMSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsBOMSaveExt.ApsBOMSaveSp(InsertFlag,
				AltNo,
				PROCPLANID,
				JSID,
				MATERIALID,
				QUANCD,
				QUANTITY,
				EFFDATE,
				OBSDATE);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
