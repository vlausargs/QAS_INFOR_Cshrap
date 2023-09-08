//PROJECT NAME: APSExt
//CLASS NAME: SLPARTnnns.cs

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
    [IDOExtensionClass("SLPARTnnns")]
    public class SLPARTnnns : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetPARTSp(int? AltNo,
		                                  [Optional] string Filter)
		{
            var iCLM_ApsGetPARTExt = new CLM_ApsGetPARTFactory().Create(this, true);

            var result = iCLM_ApsGetPARTExt.CLM_ApsGetPARTSp(AltNo,
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
		public int ApsPARTDelSp(int? AltNo,
			Guid? RowPointer)
		{
			var iApsPARTDelExt = new ApsPARTDelFactory().Create(this, true);

			var result = iApsPARTDelExt.ApsPARTDelSp(AltNo,
				RowPointer);

			return result ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsPARTSaveSp(int? InsertFlag,
		int? AltNo,
		string PARTID,
		string DESCR,
		string FAMILY,
		string PROCPLANID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsPARTSaveExt = new ApsPARTSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsPARTSaveExt.ApsPARTSaveSp(InsertFlag,
				AltNo,
				PARTID,
				DESCR,
				FAMILY,
				PROCPLANID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
