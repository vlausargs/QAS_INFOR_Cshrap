//PROJECT NAME: APSExt
//CLASS NAME: SLRGRPMBRnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLRGRPMBRnnns")]
    public class SLRGRPMBRnnns : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsNumGroupResSp(string PRGID,
                                    ref int? PNumGroupRes,
                                    short? AltNo)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsNumGroupResExt = new ApsNumGroupResFactory().Create(appDb);

                IntType oPNumGroupRes = PNumGroupRes;

                int Severity = iApsNumGroupResExt.ApsNumGroupResSp(PRGID,
                                                                   ref oPNumGroupRes,
                                                                   AltNo);

                PNumGroupRes = oPNumGroupRes;


                return Severity;
            }
        }





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RgrpMbrsUpdSp(Guid? Rowp,
		int? Seqno,
		string Rgid,
		string Resid,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRgrpMbrsUpdExt = new RgrpMbrsUpdFactory().Create(appDb);
				
				var result = iRgrpMbrsUpdExt.RgrpMbrsUpdSp(Rowp,
				Seqno,
				Rgid,
				Resid,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RgrpMbrsDelSp(Guid? Rowp,
		string PRgrp,
		string PRes,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRgrpMbrsDelExt = new RgrpMbrsDelFactory().Create(appDb);
				
				var result = iRgrpMbrsDelExt.RgrpMbrsDelSp(Rowp,
				PRgrp,
				PRes,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RgrpMbrsInsSp(string PRgrp,
		string PRes,
		int? Seqno,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRgrpMbrsInsExt = new RgrpMbrsInsFactory().Create(appDb);
				
				var result = iRgrpMbrsInsExt.RgrpMbrsInsSp(PRgrp,
				PRes,
				Seqno,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetRGRPMBRSp(string PRgId,
		int? AltNo,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetRGRPMBRExt = new CLM_ApsGetRGRPMBRFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetRGRPMBRExt.CLM_ApsGetRGRPMBRSp(PRgId,
				AltNo,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ResourceSp([Optional] string Job,
		[Optional] int? Suffix,
		[Optional] int? OperNum,
		[Optional] int? AltNo,
		[Optional] string FilterString,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ResourceExt = new CLM_ResourceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ResourceExt.CLM_ResourceSp(Job,
				Suffix,
				OperNum,
				AltNo,
				FilterString,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
