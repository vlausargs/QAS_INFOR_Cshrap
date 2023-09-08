//PROJECT NAME: APSExt
//CLASS NAME: SLAPSOPTIONSnnns.cs

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
	[IDOExtensionClass("SLAPSOPTIONSnnns")]
	public class SLAPSOPTIONSnnns : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkNumdbSp(int? Value,
		                      short? AltNo,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iChkNumdbExt = new ChkNumdbFactory().Create(appDb);
				
				int Severity = iChkNumdbExt.ChkNumdbSp(Value,
				                                       AltNo,
				                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkValueSp(string Param,
		                      string Value,
		                      short? AltNo,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iChkValueExt = new ChkValueFactory().Create(appDb);
				
				int Severity = iChkValueExt.ChkValueSp(Param,
				                                       Value,
				                                       AltNo,
				                                       ref Infobar);
				
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsDelAPSOPTIONSSp(Guid? Rowp,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsDelAPSOPTIONSExt = new ApsDelAPSOPTIONSFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsDelAPSOPTIONSExt.ApsDelAPSOPTIONSSp(Rowp,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsSaveAPSOPTIONSSp(int? InsertFlag,
		int? AltNo,
		string PARAM,
		string VALUE)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsSaveAPSOPTIONSExt = new ApsSaveAPSOPTIONSFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsSaveAPSOPTIONSExt.ApsSaveAPSOPTIONSSp(InsertFlag,
				AltNo,
				PARAM,
				VALUE);
				
				int Severity = result.Value;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetAPSOPTIONSSp(int? AltNo)
        {
            var iCLM_ApsGetAPSOPTIONSExt = new CLM_ApsGetAPSOPTIONSFactory().Create(this, true);

            var result = iCLM_ApsGetAPSOPTIONSExt.CLM_ApsGetAPSOPTIONSSp(AltNo);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
    }
}
