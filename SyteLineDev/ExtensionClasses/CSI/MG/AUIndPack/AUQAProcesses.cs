//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUQAProcesses.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Automotive;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.AUIndPack
{
    [IDOExtensionClass("AUQAProcesses")]
    public class AUQAProcesses : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AU_CalculateProjectedDateSp(string ProcessID,
                                               DateTime? StartDate,
                                               ref DateTime? ProjectedDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAU_CalculateProjectedDateExt = new AU_CalculateProjectedDateFactory().Create(appDb);

                DateType oProjectedDate = ProjectedDate;

                int Severity = iAU_CalculateProjectedDateExt.AU_CalculateProjectedDateSp(ProcessID,
                                                                                         StartDate,
                                                                                         ref oProjectedDate);

                ProjectedDate = oProjectedDate;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_QAProcessRefGetValueCompletedBySp([Optional] string RefType,
		                                                          [Optional] string RefNum,
		                                                          [Optional] string RefName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iAU_CLM_QAProcessRefGetValueExt = new AU_CLM_QAProcessRefGetValueFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iAU_CLM_QAProcessRefGetValueExt.AU_CLM_QAProcessRefGetValueSp(RefType,
				                                                                           RefNum,
				                                                                           RefName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_QAProcessRefGetValueOriginatorSp([Optional] string RefType,
		                                                         [Optional] string RefNum,
		                                                         [Optional] string RefName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iAU_CLM_QAProcessRefGetValueExt = new AU_CLM_QAProcessRefGetValueFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iAU_CLM_QAProcessRefGetValueExt.AU_CLM_QAProcessRefGetValueSp(RefType,
				                                                                           RefNum,
				                                                                           RefName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_QAProcessRefGetValueOwnerSp([Optional] string RefType,
		                                                    [Optional] string RefNum,
		                                                    [Optional] string RefName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iAU_CLM_QAProcessRefGetValueExt = new AU_CLM_QAProcessRefGetValueFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iAU_CLM_QAProcessRefGetValueExt.AU_CLM_QAProcessRefGetValueSp(RefType,
				                                                                           RefNum,
				                                                                           RefName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_QAprocessBuilderSp(byte? IncludeQAProcesses,
		byte? IncludeQAProcessDefn,
		[Optional] string QAprocessIDStarting,
		[Optional] string QAprocessIDEnding,
		[Optional] string QAProcessStarting,
		[Optional] string QAProcessEnding,
		[Optional] string ProcessSourceTypeStart,
		[Optional] string ProcessSourceTypeEnd,
		[Optional] string ProcessSourceStarting,
		[Optional] string ProcessSourceEnding,
		[Optional] decimal? UserId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_QAprocessBuilderExt = new AU_QAprocessBuilderFactory().Create(appDb);
				
				var result = iAU_QAprocessBuilderExt.AU_QAprocessBuilderSp(IncludeQAProcesses,
				IncludeQAProcessDefn,
				QAprocessIDStarting,
				QAprocessIDEnding,
				QAProcessStarting,
				QAProcessEnding,
				ProcessSourceTypeStart,
				ProcessSourceTypeEnd,
				ProcessSourceStarting,
				ProcessSourceEnding,
				UserId);
				
				
				return result.Value;
			}
		}
    }
}

