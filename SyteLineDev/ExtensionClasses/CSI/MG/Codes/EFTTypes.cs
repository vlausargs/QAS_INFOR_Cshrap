//PROJECT NAME: CodesExt
//CLASS NAME: EFTTypes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("EFTTypes")]
    public class EFTTypes : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EFTMapImportCreateDataViewSp(string EFTType,
                                                ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEFTMapImportCreateDataViewExt = new EFTMapImportCreateDataViewFactory().Create(appDb);

                InfobarType oInfoBar = InfoBar;

                int Severity = iEFTMapImportCreateDataViewExt.EFTMapImportCreateDataViewSp(EFTType,
                                                                                           ref oInfoBar);

                InfoBar = oInfoBar;


                return Severity;
            }
        }
    }
}
