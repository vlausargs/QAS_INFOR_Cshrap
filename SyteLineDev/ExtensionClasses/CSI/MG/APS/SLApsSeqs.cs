//PROJECT NAME: APSExt
//CLASS NAME: SLApsSeqs.cs

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
    [IDOExtensionClass("SLApsSeqs")]
    public class SLApsSeqs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsGetRuleValueSp(short? PRuleType,
                                     string PRuleValueDisplay,
                                     ref string PRuleValue)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsGetRuleValueExt = new ApsGetRuleValueFactory().Create(appDb);

                ApsRulevalType oPRuleValue = PRuleValue;

                int Severity = iApsGetRuleValueExt.ApsGetRuleValueSp(PRuleType,
                                                                     PRuleValueDisplay,
                                                                     ref oPRuleValue);

                PRuleValue = oPRuleValue;

                return Severity;
            }
        }




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetOPRULESp(short? AltNo,
		                                    [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetOPRULEExt = new CLM_ApsGetOPRULEFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetOPRULEExt.CLM_ApsGetOPRULESp(AltNo,
				                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetRuleValuesSp(short? PRuleType,
		                                        [Optional] string RuleValueFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetRuleValuesExt = new CLM_ApsGetRuleValuesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetRuleValuesExt.CLM_ApsGetRuleValuesSp(PRuleType,
				                                                             RuleValueFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetRuleValues2Sp(int? AltNo,
		int? PRuleType,
		[Optional] string RuleValueFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetRuleValues2Ext = new CLM_ApsGetRuleValues2Factory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetRuleValues2Ext.CLM_ApsGetRuleValues2Sp(AltNo,
				PRuleType,
				RuleValueFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int OPRULEDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iOPRULEDelExt = new OPRULEDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iOPRULEDelExt.OPRULEDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int OPRULESaveSp(int? InsertFlag,
		int? AltNo,
		int? RULESEQ,
		int? RULETYPE,
		string RULEVALUE,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iOPRULESaveExt = new OPRULESaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iOPRULESaveExt.OPRULESaveSp(InsertFlag,
				AltNo,
				RULESEQ,
				RULETYPE,
				RULEVALUE,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
