using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Localization;

namespace Blaser_ÖTV_Fatura_Irsaliye
{
    public class LocalizeGrids : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.CustomFilterDialogCancelButton: return "İptal";
                case GridStringId.CustomFilterDialogCaption: return "Filtreleme Seçenekleri";
                case GridStringId.CustomFilterDialogClearFilter: return "Filtreyi temizle";
                //case GridStringId.customfilte: return "Boşlar";
                //case GridStringId.CustomFilterDialogConditionEQU: return "Eşit (Equal)";
                //case GridStringId.CustomFilterDialogConditionLike: return "Benzer (Like)";
                //case GridStringId.CustomFilterDialogConditionNEQ: return "Eşit değil (Not Equal)";
                //case GridStringId.CustomFilterDialogConditionNonBlanks: return "Boş olmayanlar";
                case GridStringId.CustomFilterDialogFormCaption: return "FİLTRELEME SEÇENEKLERİ";
                case GridStringId.CustomFilterDialogOkButton: return "Tamam";
                case GridStringId.CustomFilterDialogRadioAnd: return "VE";
                case GridStringId.CustomFilterDialogRadioOr: return "VEYA";
                //.........
                case GridStringId.MenuFooterMaxFormat: return "En büyük ({0})";
                case GridStringId.MenuFooterMin: return "En küçük";
                case GridStringId.MenuFooterMinFormat: return "En küçük ({0})";
                case GridStringId.MenuFooterNone: return "Kaldır";
                case GridStringId.MenuFooterSum: return "Toplam";
                case GridStringId.MenuFooterSumFormat: return "Toplam ({0})";
                case GridStringId.MenuGroupPanelClearGrouping: return "Grubu Boz";
                case GridStringId.MenuGroupPanelFullCollapse: return "Tümünü Kapat";
                case GridStringId.MenuGroupPanelFullExpand: return "Tümünü Aç";

                case GridStringId.PopupFilterAll: return "(Tümü)";
                case GridStringId.PopupFilterBlanks: return "(Boşlar)";
                case GridStringId.PopupFilterCustom: return "(Özel)";
                case GridStringId.PopupFilterNonBlanks: return "(Boş olmayanlar)";

                case GridStringId.WindowErrorCaption: return "HATA";

                case GridStringId.MenuColumnSortAscending: return "A'dan Z'ye sırala";
                case GridStringId.MenuColumnSortDescending: return "Z'den A'ya sırala";
                case GridStringId.MenuColumnRemoveColumn: return "Kolonu Kaldır";
                case GridStringId.MenuColumnShowColumn: return "Kolonları Göster";
                case GridStringId.MenuColumnBestFitAllColumns: return"En Uygun Genişlik";
            }
            return "";
        }
    }
}
