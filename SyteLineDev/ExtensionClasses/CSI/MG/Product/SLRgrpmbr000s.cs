//PROJECT NAME: ProductExt
//CLASS NAME: SLRgrpmbr000s.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production.APS;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLRgrpmbr000s")]
    public class SLRgrpmbr000s : ExtensionClassBase
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
    }
}
