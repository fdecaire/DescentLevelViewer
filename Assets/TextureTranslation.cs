using System.Collections.Generic;

namespace Assets
{
    public class TextureTranslation
    {
        private Dictionary<int,int> _translationTable = new Dictionary<int, int>();

        public TextureTranslation()
        {
            _translationTable.Add(0, 721); // rock001
            _translationTable.Add(1, 722); // rock021
            _translationTable.Add(3, 723); // rock071
            _translationTable.Add(10, 728); // rock006
            _translationTable.Add(13,731); // rock014
            _translationTable.Add(16, 734); // rock022
            _translationTable.Add(38, 756); // rock095
            _translationTable.Add(42, 760); // rock101
            _translationTable.Add(58, 776); // rock146
            _translationTable.Add(62, 780); // rock152
            _translationTable.Add(65, 783); // rock159
            _translationTable.Add(66, 784); // rock160
            _translationTable.Add(68, 786); // rock164
            _translationTable.Add(71, 789); // rock169
            _translationTable.Add(73, 791); // rock171
            _translationTable.Add(75, 793); // rock173
            _translationTable.Add(76, 794); // rock174
            _translationTable.Add(77, 795); // rock175
            _translationTable.Add(81, 799); // rock179
            _translationTable.Add(82, 800); // rock180
            _translationTable.Add(83, 802); // rock181
            _translationTable.Add(88, 806); // rock187
            _translationTable.Add(90, 808); // rock189
            _translationTable.Add(91, 809); // rock190
            _translationTable.Add(92, 810); // rock191
            _translationTable.Add(94, 812); // rock193
            _translationTable.Add(98, 816); // rock198
            _translationTable.Add(107, 825); // rock208
            _translationTable.Add(113, 831); // rock215
            _translationTable.Add(116, 834); // rock218
            _translationTable.Add(120, 838); // rock223
            _translationTable.Add(123, 841); // rock226
            _translationTable.Add(126, 844); // rock229
            _translationTable.Add(127, 845); // rock230
            _translationTable.Add(129, 847); // rock232
            _translationTable.Add(130, 848); // rock233
            _translationTable.Add(135, 853); // rock239
            _translationTable.Add(142, 860); // rock251
            _translationTable.Add(143, 861); // rock252
            _translationTable.Add(145, 863); // rock254
            _translationTable.Add(150, 868); // rock260
            _translationTable.Add(151, 869); // rock261
            _translationTable.Add(152, 870); // rock262
            _translationTable.Add(156, 874); // metl002
            _translationTable.Add(162, 879); // metl011
            _translationTable.Add(166, 25); //  metl016
            _translationTable.Add(255, 970); // metl139
            _translationTable.Add(257, 731); // rock014
            _translationTable.Add(258, 973); // brig002
            _translationTable.Add(259, 974); // brig003
            _translationTable.Add(260, 975); // brig004
            _translationTable.Add(261, 976); // exit01
            _translationTable.Add(262, 977); // exit02
            _translationTable.Add(270, 985); // ceil014
            _translationTable.Add(271, 987); // ceil015
            _translationTable.Add(272, 987); // ceil016
            _translationTable.Add(274, 989); // ceil018
            _translationTable.Add(275, 990); // ceil019
            _translationTable.Add(276, 991); // ceil037
            _translationTable.Add(315, 1030); // misc044
            _translationTable.Add(322, 1037); // misc059
            _translationTable.Add(327, 1042); // arw01
            _translationTable.Add(328, 1048); // misc17
            _translationTable.Add(333, 1079); // misc11
            _translationTable.Add(335, 1091); // ctrl01
            _translationTable.Add(338, 1115); // misc14
            _translationTable.Add(339, 1123); // misc16
            _translationTable.Add(419, 1390); // door24
            _translationTable.Add(486, 1457); // door17
            _translationTable.Add(500, 1471); // door19
            _translationTable.Add(515, 1486); // door21
            _translationTable.Add(529, 1500); // door23
            _translationTable.Add(563, 1534); // door29
            _translationTable.Add(577, 1548); // door31
        }

        public int this[int index]
        {
            get
            {
                if (_translationTable.ContainsKey(index))
                {
                    if (_translationTable[index] == -1)
                        return 255;
                    return _translationTable[index];
                }

                return 255; // pwr01_0
            }
        }
    }
}
