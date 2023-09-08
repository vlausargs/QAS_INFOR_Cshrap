//PROJECT NAME: CustomerExt
//CLASS NAME: SLSalesForecasts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLSalesForecasts")]
    public class SLSalesForecasts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AddOpportunitiesToSalesForecastSp(string ForecastId,
                                                      string OpportunityId,
                                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAddOpportunitiesToSalesForecastExt = new AddOpportunitiesToSalesForecastFactory().Create(appDb);

                int Severity = iAddOpportunitiesToSalesForecastExt.AddOpportunitiesToSalesForecastSp(ForecastId,
                                                                                                     OpportunityId,
                                                                                                     ref Infobar);

                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SaveOpportunitiesToSalesForecastSp(string OppList,
		string ForecastId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSaveOpportunitiesToSalesForecastExt = new SaveOpportunitiesToSalesForecastFactory().Create(appDb);
				
				var result = iSaveOpportunitiesToSalesForecastExt.SaveOpportunitiesToSalesForecastSp(OppList,
				ForecastId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SalespersonForecastsSP(string SlsMan,
		int? IncludeDirReports,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SalespersonForecastsExt = new CLM_SalespersonForecastsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SalespersonForecastsExt.CLM_SalespersonForecastsSP(SlsMan,
				IncludeDirReports,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
