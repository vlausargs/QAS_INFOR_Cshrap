using System;

using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using Mongoose.IDO.DataAccess;

using System.Runtime.InteropServices;

using Mongoose.Core;
using KDU_Report;

namespace KDU_Report
{
    [IDOExtensionClass("KDU_ReportCutOff")]
    public class KDU_ReportCutOff : IDOExtensionClass
    {
        public override void SetContext(IIDOExtensionClassContext context)
        {
            // Call the base class implementation: 
            base.SetContext(context);

            // Add event handlers here, for example: 
            this.Context.IDO.PreLoadCollection += this.HandlePreLoadCollection;
        }
        private void HandlePreLoadCollection(object sender, IDOEventArgs args)
        {
            // Get the original request: 
            LoadCollectionRequestData loadRequest;

            loadRequest = (LoadCollectionRequestData)args.RequestPayload;
            loadRequest.LoadCap = 100000;
            loadRequest.RecordCap = 100000;

            //LoadCollectionResponseData responseData = args.ResponsePayload as LoadCollectionResponseData;
            //responseData.LoadCap = 100000;
            //responseData.RecordCap = 100000;
         
            // ...Additional logic based on loadRequest. 
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public IDataReader rpt_generalLedgertransactionSp([Optional] string pSource,
            [Optional] string pSite, [Optional] DateTime? pEndingDate,
            [Optional] int? pRemaining,
            [Optional] DateTime? pStartingDate)
        {

                using (ApplicationDB db = this.CreateApplicationDB())
                {
                db.SetProcessVariable("EnableBookmark", "False",true);
                db.SetProcessVariable("RecordCap", "5000", true);
                
                ReportCutOffQueryBuilder queryBuilder = new ReportCutOffQueryBuilder(pSource, pSite, pEndingDate, pRemaining, pStartingDate);

                //query 1
                var cmd1 = SQLFactory.createCommmand(db, queryBuilder.query1());
                DataTable dt1 = new DataTable();
                dt1.Load(cmd1.ExecuteReader());

                //var cmd2 = SQLFactory.createCommmand(db, queryBuilder.query2());
                //DataTable dt2 = new DataTable();
                //dt2.Load(cmd2.ExecuteReader());

                //var cmd3 = SQLFactory.createCommmand(db, queryBuilder.query3());
                //DataTable dt3 = new DataTable();
                //dt3.Load(cmd3.ExecuteReader());

                //var cmd4 = SQLFactory.createCommmand(db, queryBuilder.query4());
                //DataTable dt4 = new DataTable();
                //dt4.Load(cmd4.ExecuteReader());

                DataTable masterDt = new DataTable();
                masterDt.Merge(dt1);
                //masterDt.Merge(dt2);
                //masterDt.Merge(dt3);
                //masterDt.Merge(dt4);
                IDataReader reader = dt1.CreateDataReader();
                return reader;
                }


        }
    }
}
