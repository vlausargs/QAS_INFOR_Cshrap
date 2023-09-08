//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPosRqmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLPosRqmts")]
    public class SLPosRqmts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable RequirementListSp(string ReqType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iRequirementListExt = new RequirementListFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iRequirementListExt.RequirementListSp(ReqType);

                return dt;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RequirementValidSp(string ReqType,
		string Requirement,
		ref string DerDescription,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRequirementValidExt = new RequirementValidFactory().Create(appDb);
				
				var result = iRequirementValidExt.RequirementValidSp(ReqType,
				Requirement,
				DerDescription,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DerDescription = result.DerDescription;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
