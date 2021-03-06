﻿using System.Collections.Generic;

namespace Assets
{
    public class TextureTranslation
    {
        private Dictionary<int,int> _translationTable = new Dictionary<int, int>();

        public TextureTranslation()
        {
            // populate the rock translations
            /*
            for (int i = 721; i < 874; i++)
            {
                _translationTable.Add(i-721, i);
            }
            */
            _translationTable.Add(0, 721); // rock001
            _translationTable.Add(1, 722); // rock021
            _translationTable.Add(3, 723); // rock071
            _translationTable.Add(6, 724); // rock002
            _translationTable.Add(7, 725); // 
            _translationTable.Add(8, 726); // 
            _translationTable.Add(9, 727); // 
            _translationTable.Add(10, 728); // rock006
            _translationTable.Add(11, 729); // rock007
            _translationTable.Add(12, 730); // rock013
            _translationTable.Add(13,731); // rock014
            _translationTable.Add(14, 732); // rock019
            _translationTable.Add(15, 733); // rock020
            _translationTable.Add(16, 734); // rock022
            _translationTable.Add(17, 735); // 
            _translationTable.Add(18, 736); // 
            _translationTable.Add(19, 737); // 
            _translationTable.Add(20, 738); // 
            _translationTable.Add(21, 739); // 
            _translationTable.Add(22, 740); // 
            _translationTable.Add(23, 741); // 
            _translationTable.Add(24, 742); // 
            _translationTable.Add(25, 743); // 
            _translationTable.Add(26, 744); // 
            _translationTable.Add(27, 745); // 
            _translationTable.Add(28, 746); // 
            _translationTable.Add(29, 747); // 
            _translationTable.Add(30, 748); // 
            _translationTable.Add(31, 749); // 
            _translationTable.Add(32, 750); // 
            _translationTable.Add(33, 751); // 
            _translationTable.Add(34, 752); // 
            _translationTable.Add(35, 753); // 
            _translationTable.Add(36, 754); // 
            _translationTable.Add(37, 755); // 
            _translationTable.Add(38, 756); // rock095
            _translationTable.Add(39, 757); // 
            _translationTable.Add(40, 758); // 
            _translationTable.Add(41, 759); // 
            _translationTable.Add(42, 760); // rock101
            _translationTable.Add(43, 761); // 
            _translationTable.Add(44, 762); // 
            _translationTable.Add(45, 763); // 
            _translationTable.Add(46, 764); // 
            _translationTable.Add(47, 765); // 
            _translationTable.Add(48, 766); // 
            _translationTable.Add(49, 767); // 
            _translationTable.Add(50, 768); // 
            _translationTable.Add(51, 769); // 
            _translationTable.Add(52, 770); // 
            _translationTable.Add(53, 771); // 
            _translationTable.Add(54, 772); // 
            _translationTable.Add(55, 773); // 
            _translationTable.Add(56, 774); // 
            _translationTable.Add(57, 775); // 
            _translationTable.Add(58, 776); // rock146
            _translationTable.Add(59, 777); // 
            _translationTable.Add(60, 778); // 
            _translationTable.Add(61, 779); // 
            _translationTable.Add(62, 780); // rock152
            _translationTable.Add(63, 781); // 
            _translationTable.Add(64, 782); // 
            _translationTable.Add(65, 783); // rock159
            _translationTable.Add(66, 784); // rock160
            _translationTable.Add(67, 785); // 
            _translationTable.Add(68, 786); // rock164
            _translationTable.Add(69, 787); // 
            _translationTable.Add(70, 788); // 
            _translationTable.Add(71, 789); // rock169
            _translationTable.Add(72, 790); // 
            _translationTable.Add(73, 791); // rock171
            _translationTable.Add(74, 792); // 
            _translationTable.Add(75, 793); // rock173
            _translationTable.Add(76, 794); // rock174
            _translationTable.Add(77, 795); // rock175
            _translationTable.Add(78, 796); // 
            _translationTable.Add(79, 797); // 
            _translationTable.Add(80, 798); // 
            _translationTable.Add(81, 799); // rock179
            _translationTable.Add(82, 800); // rock180
            _translationTable.Add(83, 801); // rock181
            _translationTable.Add(84, 802); // 
            _translationTable.Add(85, 803); // 
            _translationTable.Add(86, 804); // 
            _translationTable.Add(87, 805); // 
            _translationTable.Add(88, 806); // rock187
            _translationTable.Add(89, 807); // 
            _translationTable.Add(90, 808); // rock189
            _translationTable.Add(91, 809); // rock190
            _translationTable.Add(92, 810); // rock191
            _translationTable.Add(93, 811); // 
            _translationTable.Add(94, 812); // rock193
            _translationTable.Add(95, 813); // 
            _translationTable.Add(96, 814); // 
            _translationTable.Add(97, 815); // 
            _translationTable.Add(98, 816); // rock198
            _translationTable.Add(99, 817); // 
            _translationTable.Add(100, 818); // 
            _translationTable.Add(101, 819); // 
            _translationTable.Add(102, 820); // 
            _translationTable.Add(103, 821); // 
            _translationTable.Add(104, 822); // 
            _translationTable.Add(105, 823); // 
            _translationTable.Add(106, 824); // 
            _translationTable.Add(107, 825); // rock208
            _translationTable.Add(108, 826); // 
            _translationTable.Add(109, 827); // 
            _translationTable.Add(110, 828); // 
            _translationTable.Add(111, 829); // 
            _translationTable.Add(112, 830); // 
            _translationTable.Add(113, 831); // rock215
            _translationTable.Add(116, 834); // rock218
            _translationTable.Add(117, 835); // 
            _translationTable.Add(118, 836); // 
            _translationTable.Add(119, 837); // 
            _translationTable.Add(120, 838); // rock223
            _translationTable.Add(121, 839); // 
            _translationTable.Add(122, 840); // 
            _translationTable.Add(123, 841); // rock226
            _translationTable.Add(124, 842); // 
            _translationTable.Add(125, 843); // 
            _translationTable.Add(126, 844); // rock229
            _translationTable.Add(127, 845); // rock230
            _translationTable.Add(129, 847); // rock232
            _translationTable.Add(130, 848); // rock233
            _translationTable.Add(131, 849); // 
            _translationTable.Add(132, 850); // 
            _translationTable.Add(133, 851); // 
            _translationTable.Add(134, 852); // 
            _translationTable.Add(135, 853); // rock239
            _translationTable.Add(136, 854); // 
            _translationTable.Add(139, 857); // 
            _translationTable.Add(140, 858); // 
            _translationTable.Add(141, 859); // 
            _translationTable.Add(142, 860); // rock251
            _translationTable.Add(143, 861); // rock252
            _translationTable.Add(144, 862); // 
            _translationTable.Add(145, 863); // rock254
            _translationTable.Add(146, 864); // 
            _translationTable.Add(147, 865); // 
            _translationTable.Add(148, 866); // 
            _translationTable.Add(149, 867); // 
            _translationTable.Add(150, 868); // rock260
            _translationTable.Add(151, 869); // rock261
            _translationTable.Add(152, 870); // rock262
            _translationTable.Add(153, 871); // 
            _translationTable.Add(154, 872); // 
            _translationTable.Add(155, 873); // 

            _translationTable.Add(156, 874); // metl002
            _translationTable.Add(157, 875); // metl003
            _translationTable.Add(158, 876); // metl004
            _translationTable.Add(159, 877); // metl006
            _translationTable.Add(161, 17); // metl009
            _translationTable.Add(162, 879); // metl011
            _translationTable.Add(163, 880); // metl013
            _translationTable.Add(164, 881); // metl014
            _translationTable.Add(165, 882); // metl015
            _translationTable.Add(166, 25); //  metl016
            _translationTable.Add(167, 883); // metl017
            _translationTable.Add(169, 885); // metl019
            _translationTable.Add(170, 886); // metl020
            _translationTable.Add(171, 24); // metl021
            _translationTable.Add(172, 887); // metl023
            _translationTable.Add(173, 888); // metl024
            _translationTable.Add(174, 889); // metl026
            _translationTable.Add(175, 890); // metl029
            _translationTable.Add(176, 891); // metl030
            _translationTable.Add(177, 892); // metl031
            _translationTable.Add(178, 893); // 
            _translationTable.Add(179, 896); // 

            _translationTable.Add(181, 894); // metl039

            _translationTable.Add(183, 898); // metl041
            _translationTable.Add(186, 901); // metl045
            _translationTable.Add(187, 902); // metl046
            _translationTable.Add(188, 903); // metl047
            _translationTable.Add(189, 904); // metl048
            _translationTable.Add(190, 905); // metl049
            _translationTable.Add(191, 906); // metl050
            _translationTable.Add(192, 907); // metl053

            _translationTable.Add(194, 909); // metl055

            _translationTable.Add(196, 911); // metl059
            _translationTable.Add(197, 912); // metl060
            _translationTable.Add(198, 913); // metl061
            _translationTable.Add(199, 914); // metl063

            _translationTable.Add(201, 916); // metl065
            _translationTable.Add(202, 917); // metl066
            _translationTable.Add(203, 918); // metl068
            _translationTable.Add(204, 919); // metl070
            _translationTable.Add(205, 920); // metl071
            _translationTable.Add(206, 921); // metl074
            _translationTable.Add(207, 922); // metl076
            _translationTable.Add(208, 923); // metl077
            _translationTable.Add(209, 924); // metl012
            _translationTable.Add(210, 925); // metl028

            _translationTable.Add(212, 927); // metl078
            _translationTable.Add(213, 928); // metl079
            _translationTable.Add(214, 929); // metl080

            _translationTable.Add(217, 932); // metl083
            _translationTable.Add(218, 933); // metl086
            _translationTable.Add(219, 934); // metl087
            _translationTable.Add(220, 935); // metl088
            _translationTable.Add(221, 936); // metl089
            _translationTable.Add(222, 937); // metl090
            _translationTable.Add(223, 938); // metl095

            _translationTable.Add(226, 941); // metl098
            _translationTable.Add(227, 942); // metl099
            _translationTable.Add(228, 943); // metl100
            _translationTable.Add(229, 944); // metl103
            _translationTable.Add(230, 945); // metl104
            _translationTable.Add(231, 946); // metl105
            _translationTable.Add(232, 947); // metl106
            _translationTable.Add(233, 948); // metl109
            _translationTable.Add(234, 949); // metl110
            _translationTable.Add(235, 950); // metl111
            _translationTable.Add(236, 951); // metl112
            _translationTable.Add(237, 952); // metl113
            _translationTable.Add(238, 953); // metl114

            _translationTable.Add(240, 955); // metl118
            _translationTable.Add(241, 956); // metl119
            _translationTable.Add(242, 957); // metl120
            _translationTable.Add(243, 958); // metl121
            _translationTable.Add(244, 959); // metl123

            _translationTable.Add(246, 961); // metl127

            _translationTable.Add(249, 964); // metl130
            _translationTable.Add(250, 965); // metl126

            _translationTable.Add(252, 967); // metl134

            _translationTable.Add(255, 970); // metl139
            _translationTable.Add(256, 971); // metl140
            _translationTable.Add(257, 731); // rock014
            _translationTable.Add(258, 973); // brig002
            _translationTable.Add(259, 974); // brig003
            _translationTable.Add(260, 975); // brig004
            _translationTable.Add(261, 976); // exit01
            _translationTable.Add(262, 977); // exit02
            _translationTable.Add(263, 978); // ceil001
            _translationTable.Add(270, 985); // ceil014
            _translationTable.Add(271, 987); // ceil015
            _translationTable.Add(272, 987); // ceil016
            _translationTable.Add(273, 988); // ceil017
            _translationTable.Add(274, 989); // ceil018
            _translationTable.Add(275, 990); // ceil019
            _translationTable.Add(276, 991); // ceil037
            _translationTable.Add(281, 996); // ceil024

            _translationTable.Add(284, 999); // ceil027

            _translationTable.Add(289, 1004); // empty - light

            _translationTable.Add(313, 1028); // misc042

            _translationTable.Add(315, 1030); // misc044
            _translationTable.Add(316, 1031); // misc045

            _translationTable.Add(322, 1037); // misc059

            _translationTable.Add(325, 1040); // fan03

            _translationTable.Add(327, 1042); // arw01
            _translationTable.Add(328, 1048); // misc17
            _translationTable.Add(329, 1064); // fan01
            _translationTable.Add(333, 1079); // misc11
            _translationTable.Add(334, 1083); // ctrl04
            _translationTable.Add(335, 1091); // ctrl01
            _translationTable.Add(336, 1099); // ctrl02
            _translationTable.Add(337, 1107); // ctrl03
            _translationTable.Add(338, 1115); // misc14
            _translationTable.Add(339, 1123); // misc16

            _translationTable.Add(347, 1150); // misc065

            _translationTable.Add(349, 1158); // misc066

            _translationTable.Add(413, 1384); // door10

            _translationTable.Add(419, 1390); // door24

            _translationTable.Add(436, 1407); // door11

            _translationTable.Add(486, 1457); // door17

            _translationTable.Add(492, 1463); // door18

            _translationTable.Add(500, 1471); // door19

            _translationTable.Add(508, 1479); // door20

            _translationTable.Add(515, 1486); // door21

            _translationTable.Add(521, 1492); // door22

            _translationTable.Add(529, 1500); // door23

            _translationTable.Add(536, 1507); // door25

            _translationTable.Add(543, 1514); // door26

            _translationTable.Add(563, 1534); // door29

            _translationTable.Add(570, 1541); // door30

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
