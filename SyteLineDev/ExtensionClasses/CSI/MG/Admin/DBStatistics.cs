//PROJECT NAME: AdminExt
//CLASS NAME: DBStatistics.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("DBStatistics")]
    public class DBStatistics : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetLockedDBObjectsSp(ref int? LockedUsers,
                                        ref int? LockedFunctions,
                                        ref int? LockedJournals)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetLockedDBObjectsExt = new GetLockedDBObjectsFactory().Create(appDb);

                IntType oLockedUsers = LockedUsers;
                IntType oLockedFunctions = LockedFunctions;
                IntType oLockedJournals = LockedJournals;

                int Severity = iGetLockedDBObjectsExt.GetLockedDBObjectsSp(ref oLockedUsers,
                                                                           ref oLockedFunctions,
                                                                           ref oLockedJournals);

                LockedUsers = oLockedUsers;
                LockedFunctions = oLockedFunctions;
                LockedJournals = oLockedJournals;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None)]
        public int PerformTaskById(string AppTaskId, string SpName, string DBName)
        {
            string infobar = "";
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDB = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);
                bool isCloud = IDORuntime.Context.LicenseInfo.SAASEnabled;

                var iAdminExt = new DBTaskFactory().Create(appDB, mgInvoker, isCloud);
                int Severity = iAdminExt.PerformTaskById(AppTaskId, SpName, DBName, ref infobar);

                if (infobar != "")
                {
                    Severity = 16;
                    throw new System.Exception(infobar);
                }

                return Severity;
            }
        }



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetTableStatisticsSp([Optional] string filterString,
		[Optional] string DatabaseName,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetTableStatisticsExt = new GetTableStatisticsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetTableStatisticsExt.GetTableStatisticsSp(filterString,
				DatabaseName,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}

