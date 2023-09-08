//PROJECT NAME: MG
//CLASS NAME: SLBGTaskHistories.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.MG.MGCore;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.MG.Admin
{
	[IDOExtensionClass("SLBGTaskHistories")]
	public class SLBGTaskHistories : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_BGTaskAnalysisSp(string FilterString,
			[Optional] DateTime? StartDate,
			[Optional] DateTime? EndDate,
			[Optional] string DatabaseName,
			[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
			    IExecuteDynamicSQLFactory executeDynamicSQLFactory = new ExecuteDynamicSQLFactory();
				IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
				IHighDateFactory highDateFactory = new HighDateFactory();
				IDayEndOfFactory dayEndOfFactory = new DayEndOfFactory();
				ILowDateFactory lowDateFactory = new LowDateFactory();
		        var iHome_BGTaskAnalysisExt = new Home_BGTaskAnalysisFactory(executeDynamicSQLFactory, midnightOfFactory, highDateFactory, dayEndOfFactory,
					lowDateFactory).Create(appDb,
						bunchedLoadCollection,
						mgInvoker,
						new CSI.Data.SQL.SQLParameterProvider(),
						true);
				
				var result = iHome_BGTaskAnalysisExt.Home_BGTaskAnalysisSp(FilterString,
					StartDate,
					EndDate,
					DatabaseName,
					Site);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
