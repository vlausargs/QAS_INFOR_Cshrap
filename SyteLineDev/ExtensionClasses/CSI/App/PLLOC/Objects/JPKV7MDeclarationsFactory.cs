using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Objects;
using PLLOC.Interfaces;
using CSI.Data.SQL;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Utilities;
using CSI.Data.Functions;

namespace PLLOC.Objects
{
    public class JPKV7MDeclarationsFactory : IJPKV7MDeclarationsFactory
    {
        public IJPKV7MDeclarations Create(string declarationCommitmentType, string declarationFormCode, string declarationSchemaVersion, string declarationSystemCode, string declarationTaxCode, string variantDeclarationForm, string confirmation, decimal p10, decimal p11, decimal p12, decimal p13, decimal p14, decimal p15, decimal p16, decimal p17, decimal p18, decimal p19, decimal p20, decimal p21, decimal p22, decimal p23, decimal p24, decimal p25, decimal p26, decimal p27, decimal p28, decimal p29, decimal p30, decimal p31, decimal p32, decimal p33, decimal p34, decimal p35, decimal p36, decimal p37, decimal p38, decimal p39, decimal p40, decimal p41, decimal p42, decimal p43, decimal p44, decimal p45, decimal p46, decimal p47, decimal p48, decimal p49, decimal p50, decimal p51, decimal p52, decimal p53, decimal p54, byte? p540, byte? p55, byte? p56, byte? p560, byte? p57, byte? p58, byte? p59, decimal p60, string p61, decimal p62, byte? p63, byte? p64, byte? p65, byte? p66, byte? p660, byte? p67, decimal? p68, decimal? p69, string pORDZU)
        {
            return new JPKV7MDeclarations(declarationCommitmentType, declarationFormCode, declarationSchemaVersion, declarationSystemCode, declarationTaxCode, variantDeclarationForm, confirmation, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40, p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p540, p55, p56, p560, p57, p58, p59, p60, p61, p62, p63, p64, p65, p66, p660, p67, p68, p69, pORDZU);
        }
    }
}
