//PROJECT NAME: MaterialExt
//CLASS NAME: SLEcns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLEcns")]
    public class SLEcns : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EcnPostSp(int? SelEcnNum,
                              ref int? EcnLineCount,
                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEcnPostExt = new EcnPostFactory().Create(appDb);

                IntType oEcnLineCount = EcnLineCount;
                InfobarType oInfobar = Infobar;

                int Severity = iEcnPostExt.EcnPostSp(SelEcnNum,
                                                    ref oEcnLineCount,
                                                    ref oInfobar);

                EcnLineCount = oEcnLineCount;
                Infobar = oInfobar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ChgStatSp(string ProcSel,
		                           string EcnFStat,
		                           string EcnTStat,
		                           [Optional] int? EcnFrom,
		                           [Optional] int? EcnTo,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iChgStatExt = new ChgStatFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iChgStatExt.ChgStatSp(ProcSel,
				                                   EcnFStat,
				                                   EcnTStat,
				                                   EcnFrom,
				                                   EcnTo,
				                                   Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateEcnEsigSp(string UserName,
			string ReasonCode,
			string ECNNum,
			ref Guid? EsigRowpointer)
		{
			var iCreateEcnEsigExt = new CreateEcnEsigFactory().Create(this, true);

			var result = iCreateEcnEsigExt.CreateEcnEsigSp(UserName,
				ReasonCode,
				ECNNum,
				EsigRowpointer);

			EsigRowpointer = result.EsigRowpointer;

			return result.ReturnCode ?? 0;
		}
	}
}
