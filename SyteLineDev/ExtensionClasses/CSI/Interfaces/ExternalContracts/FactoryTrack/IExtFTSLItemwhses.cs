
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLItemwhses
    {

        int ItemwhseCheckCntInProcSp(string Whse,
                string Item,
                byte? CheckLotTracked,
                byte? CheckSerialTracked,
                string FormTitle,
                ref string Description,
                ref string UM,
                ref byte? ItemSerialTracked,
                ref byte? ItemLotTracked,
                ref decimal? QtyOnHand,
                ref string Infobar,
                [Optional] ref string Prompt,
                [Optional] ref string PromptButtons); 

        int ItemwhseGetDetailsSp(string Item,
                string Whse,
                ref decimal? QtyOnHand,
                ref decimal? QtyReorder,
                ref int? CntInProc,
                ref int? CycleFlag,
                ref string Loc,
                ref string Infobar); 

    }
}
    
