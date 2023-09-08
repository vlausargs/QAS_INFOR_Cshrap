//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUQAProcessSources.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using CSI.Data.SQL;
using Mongoose.IDO.Protocol;
using CSI.Production.Automotive;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.AUIndPack
{
    [IDOExtensionClass("AUQAProcessSources")]
    public class AUQAProcessSources : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_CheckQAProcessSourceValueSp([Optional] string RefType,
		                                          [Optional] string RefNum,
		                                          [Optional] short? RefLineSuf,
		                                          [Optional] short? RefRelease,
		                                          [Optional] int? SourceLevel,
		                                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_CheckQAProcessSourceValueExt = new AU_CheckQAProcessSourceValueFactory().Create(appDb);
				
				var result = iAU_CheckQAProcessSourceValueExt.AU_CheckQAProcessSourceValueSp(RefType,
				                                                                             RefNum,
				                                                                             RefLineSuf,
				                                                                             RefRelease,
				                                                                             SourceLevel,
				                                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_QAProcessSourceGetValueSp([Optional] string RefType,
		[Optional] string RefNum,
		[Optional] int? RefLineSuf,
		[Optional, DefaultParameterValue(1)] int? SourceLevel)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_CLM_QAProcessSourceGetValueExt = new AU_CLM_QAProcessSourceGetValueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_CLM_QAProcessSourceGetValueExt.AU_CLM_QAProcessSourceGetValueSp(RefType,
				RefNum,
				RefLineSuf,
				SourceLevel);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
