//PROJECT NAME: BusInterfaceExt
//CLASS NAME: SLTmpAckPos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("SLTmpAckPos")]
    public class SLTmpAckPos : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SupplyWEBInPoAckSp(Guid? TmpAckPoRowPointer,
                                      string FromLogicalID,
                                      string FromReferenceID,
                                      DateTime? FromCreateTime,
                                      string FromBODID,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);

                var iSupplyWEBInPoAckExt = new SupplyWEBInPoAckFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iSupplyWEBInPoAckExt.SupplyWEBInPoAckSp(TmpAckPoRowPointer,
                FromLogicalID,
                FromReferenceID,
                FromCreateTime,
                FromBODID,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }
    }
}
