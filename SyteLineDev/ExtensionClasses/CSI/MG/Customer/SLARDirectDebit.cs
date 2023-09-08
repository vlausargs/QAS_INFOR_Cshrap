//PROJECT NAME: CustomerExt
//CLASS NAME: SLARDirectDebit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLARDirectDebit")]
    public class SLARDirectDebit : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_DirectDebitPurgeSp(int? pStartDirectDebitNum,
                                                int? pEndDirectDebitNum,
                                                string pStatus,
                                                byte? pCommit,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_DirectDebitPurgeExt = new CLM_DirectDebitPurgeFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCLM_DirectDebitPurgeExt.CLM_DirectDebitPurgeSp(pStartDirectDebitNum,
                                                                               pEndDirectDebitNum,
                                                                               pStatus,
                                                                               pCommit,
                                                                               ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_VoidDirectDebitSp(int? pStartDirectDebitNum,
		                                       int? pEndDirectDebitNum,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_VoidDirectDebitExt = new CLM_VoidDirectDebitFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_VoidDirectDebitExt.CLM_VoidDirectDebitSp(pStartDirectDebitNum,
				                                                             pEndDirectDebitNum,
				                                                             ref Infobar);
				
				return dt;
			}
		}
    }
}
