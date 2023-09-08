//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBChartOfAccountsViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBChartOfAccountsViews")]
	public class ESBChartOfAccountsViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBChartofAccountsSP(string ActionExpression,
		                                    string Account,
		                                    string Description,
		                                    string AccountTypeType,
		                                    string EnterAnl1,
		                                    string EnterAnl2,
		                                    string EnterAnl3,
		                                    string EnterAnl4,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBChartofAccountsExt = new LoadESBChartofAccountsFactory().Create(appDb);
				
				int Severity = iLoadESBChartofAccountsExt.LoadESBChartofAccountsSP(ActionExpression,
				                                                                   Account,
				                                                                   Description,
				                                                                   AccountTypeType,
				                                                                   EnterAnl1,
				                                                                   EnterAnl2,
				                                                                   EnterAnl3,
				                                                                   EnterAnl4,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBChartOfAccountsSp(string Account)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBChartOfAccountsExt = new CLM_ESBChartOfAccountsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBChartOfAccountsExt.CLM_ESBChartOfAccountsSp(Account);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
