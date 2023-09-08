//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBJobResourceViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("ESBJobResourceViews")]
    public class ESBJobResourceViews : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LoadESBJrtResourceGroupSp(string job,
                                             short? Suffix,
                                             int? OperNum,
                                             string ActionExpression,
                                             string rgid,
                                             short? QtyResources,
                                             string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iLoadESBJrtResourceGroupExt = new LoadESBJrtResourceGroupFactory().Create(appDb);

                int Severity = iLoadESBJrtResourceGroupExt.LoadESBJrtResourceGroupSp(job,
                                                                                     Suffix,
                                                                                     OperNum,
                                                                                     ActionExpression,
                                                                                     rgid,
                                                                                     QtyResources,
                                                                                     Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBJobResourceSP(string Job,
        int? Suffix,
        int? OperNum)
        {
            var iCLM_ESBJobResourceExt = this.GetService<ICLM_ESBJobResource>();

            var result = iCLM_ESBJobResourceExt.CLM_ESBJobResourceSP(Job,
            Suffix,
            OperNum);

            return result.Data.ToDataTable();
        }
    }
}