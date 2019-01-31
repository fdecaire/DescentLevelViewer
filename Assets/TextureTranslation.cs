using System.Collections.Generic;

namespace Assets
{
    public class TextureTranslation
    {
        private Dictionary<int,int> _translationTable = new Dictionary<int, int>();

        public TextureTranslation()
        {
            _translationTable.Add(0, 721); // rock001
            _translationTable.Add(13,731); // rock014
            _translationTable.Add(271, 987); // ceil015
            _translationTable.Add(166, 25); //  metl016
            _translationTable.Add(162, 879); // metl011
            _translationTable.Add(327, 1042); // arw01
            _translationTable.Add(272, 987); // ceil016
            _translationTable.Add(275, 990); // ceil019
            _translationTable.Add(335, 1091); // ctrl01
            _translationTable.Add(16, 734); // rock022
            _translationTable.Add(3, 723); // rock071
            _translationTable.Add(83, 802); // rock181
            _translationTable.Add(486, 1457); // door17
            _translationTable.Add(261, 976); // exit01
            _translationTable.Add(262, 977); // exit02
            _translationTable.Add(38, 756); // rock095
            _translationTable.Add(10, 728); // rock006
            _translationTable.Add(577, 1548); // door31
            _translationTable.Add(276, 991); // ceil037
            _translationTable.Add(257, 731); // rock014
            _translationTable.Add(258, 973); // brig002
            _translationTable.Add(259, 974); // brig003
            _translationTable.Add(260, 975); // brig004
            _translationTable.Add(58, 776); // rock146
            _translationTable.Add(151, 869); // rock261
            _translationTable.Add(130, 848); // rock233
            _translationTable.Add(143, 861); // rock252
            _translationTable.Add(333, 1079); // misc11
            _translationTable.Add(142, 860); // rock251
            _translationTable.Add(1, 722); // rock021
            _translationTable.Add(419, 1390); // door24
            _translationTable.Add(322, 1037); // misc059
            _translationTable.Add(328, 1048); // misc17
        }

        public int this[int index]
        {
            get
            {
                if (_translationTable.ContainsKey(index))
                {
                    return _translationTable[index];
                }

                return 255; // pwr01_0
            }
        }
    }
}
