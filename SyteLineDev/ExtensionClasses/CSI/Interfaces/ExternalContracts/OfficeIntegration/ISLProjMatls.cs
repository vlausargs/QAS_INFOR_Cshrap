using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.OfficeIntegration.Project
{
    public interface ISLProjMatls
    {
        int prjresValidateItemSp(ref string PItem,
                                        string POldItem,
                                        string PProj,
                                        byte? PAddMode,
                                        ref decimal? PCost,
                                        ref byte? PBackflush,
                                        ref string PRefType,
                                        ref string PMatlType,
                                        ref string PUnits,
                                        ref decimal? PMatlCost,
                                        ref decimal? PLbrCost,
                                        ref decimal? PFovhdCost,
                                        ref decimal? PVovhdCost,
                                        ref decimal? POutCost,
                                        ref decimal? PFmatlovhd,
                                        ref decimal? PVmatlovhd,
                                        ref string PUM,
                                        ref byte? PItemAvail,
                                        ref string PItemDesc,
                                        ref byte? PItemSerialTracked,
                                        ref string PCostCode,
                                        ref string Infobar,
                                        ref string Prompt,
                                        ref string PromptButtons,
                                        ref byte? SupplQtyReq,
                                        ref double? SupplQtyConvFactor,
                                        ref string Origin,
                                        ref string CommCode,
                                        ref decimal? UnitWeight,
                                        ref byte? Kit);
    }
}
