﻿// Nir Leibovitch 200315232

// surround code with an IEFE so variables & function declarations don't leak to the global object
(function () {
    var canvas = document.getElementById('sheep');
    // wait for DOM ready
    $(document).ready(function () {
        if (canvas.getContext) {
            var ctx = canvas.getContext('2d');

            var body = new Path2D("M 423.09375,245.21875 C 416.54409,245.30874 416.13237,255.94799 409.25130,253.41770 C 381.02671,252.53738 352.72624,249.11197 324.51088,251.05333 C 276.82684,256.85269 236.30967,292.16163 217.69826,335.53179 C 210.63109,351.41972 206.37187,368.47267 204.75000,385.78125 C 192.72688,386.94687 187.87470,404.97205 197.65625,411.90625 C 192.96049,416.59661 189.37174,423.32460 192.56018,429.94604 C 193.35186,434.49832 199.87752,437.13224 201.15625,439.31250 C 195.66525,447.20425 200.15779,460.13826 209.78125,462.06250 C 209.56624,468.01700 215.20092,471.75617 218.08956,475.80087 C 219.23442,483.04802 226.39291,488.77188 233.71875,488.28125 C 235.57427,497.45587 247.53756,502.36101 255.53125,497.84375 C 257.15032,508.80953 271.45010,514.95908 280.06250,507.62500 C 286.98186,509.76088 294.24269,510.37015 301.09375,512.43750 C 306.66707,515.94899 313.21309,515.24246 318.62959,512.00401 C 325.35404,512.75626 331.11744,520.44956 338.62429,517.68104 C 343.68276,517.27790 345.92377,510.28441 351.40223,512.90798 C 357.08667,511.38286 360.81228,513.53661 365.21213,516.58510 C 373.74797,517.63352 382.41685,517.11943 390.94334,518.47270 C 396.67571,519.22992 402.48729,515.13475 408.25000,518.06250 C 414.41610,518.67129 417.91730,511.57715 424.03125,513.12500 C 429.49153,509.67154 431.58004,515.82313 436.27703,517.14474 C 442.00301,519.10573 449.09972,517.55823 452.90625,512.68750 C 457.72937,515.95024 464.13132,507.74944 466.96875,513.37500 C 474.39528,520.07352 488.34972,517.23464 491.53125,507.59375 C 497.27442,511.20689 505.07479,515.19881 511.32017,510.40986 C 514.85919,506.94792 517.89494,503.36503 523.28125,503.90625 C 530.53242,501.72002 533.36976,492.83594 541.53991,492.75782 C 547.92088,491.97804 552.02202,487.28284 554.37500,481.68750 C 564.24099,482.03785 572.03350,470.19083 567.56250,461.25000 C 572.46956,459.17894 570.60258,451.13944 575.46875,450.78125 C 584.29252,447.66612 589.11920,435.23936 582.59375,427.81250 C 582.95728,422.08303 587.35963,419.43649 590.23165,415.22192 C 592.92106,410.54959 592.41170,404.24093 589.12500,399.96875 C 590.87856,394.06201 587.23795,388.18291 587.81250,382.15625 C 585.44921,377.90627 581.22247,374.61105 586.96875,371.03125 C 590.44250,365.07772 588.98739,356.61135 583.50000,352.37500 C 585.90213,344.86418 579.92823,337.86193 576.56250,331.65625 C 571.47182,329.14503 570.34775,325.06389 572.00000,320.03125 C 572.33208,312.22517 564.36625,306.53011 558.46875,304.93750 C 559.06129,297.85646 553.82350,290.66899 546.81250,289.31250 C 544.80216,282.82744 536.11769,281.93560 534.28671,275.20949 C 529.10604,268.16838 518.77743,268.25768 512.03279,272.28828 C 508.05308,268.43592 506.27056,261.27100 499.36163,261.12673 C 494.20135,261.11979 489.03015,260.34585 486.99003,255.00268 C 481.02044,248.50531 469.17773,248.77180 463.81250,255.75000 C 459.92289,251.05863 455.45197,246.26477 448.71875,246.93750 C 442.72051,247.79729 439.20489,252.07978 434.66763,246.37100 C 431.20813,244.30010 426.91777,244.37572 423.09375,245.21875 z");
            var rightEar = new Path2D("M 195.21371,180.36113 C 232.50708,156.07667 257.48818,145.83866 275.15682,172.97222 C 287.58817,192.06291 264.51105,224.57243 227.21767,248.85690 C 189.92432,273.14134 156.90027,288.61669 144.46895,269.52603 C 132.03763,250.43537 157.92033,204.64558 195.21371,180.36113 z");
            var face = new Path2D("M 300.68682,142.46824 C 270.53087,144.98138 241.67847,159.63359 221.27125,181.88065 C 175.03318,189.48561 132.91247,226.38845 126.29610,273.89185 C 119.37624,316.20001 143.44665,359.42603 180.25710,379.97817 C 230.09590,409.61546 300.43409,400.19159 338.43725,355.53323 C 356.84595,334.91377 365.44933,306.95365 364.04030,279.54514 C 364.46903,244.79223 379.10564,225.47153 361.17704,175.18150 C 353.45451,153.51971 331.15447,142.32219 310.12373,142.24136 C 306.97692,142.15489 303.82607,142.23666 300.68682,142.46824 z");
            var leftEye = new Path2D("M 241.15133,165.68358 C 238.34586,165.95816 234.89153,167.24280 231.53032,169.39696 C 225.03720,173.55831 221.19244,179.53452 222.58446,183.06893 C 227.77136,182.69057 234.15590,180.45231 240.47617,176.40173 C 243.07872,174.73379 245.30350,172.83006 247.39655,170.91607 C 247.61573,169.76876 247.51735,168.74559 247.05897,167.87785 C 246.14224,166.14240 243.95681,165.40901 241.15133,165.68358 z");
            var rightEye = new Path2D("M 270.42625,173.61036 C 264.06452,173.40389 257.73272,178.37395 256.49380,185.12886 C 256.42191,186.66091 257.56731,187.84630 258.47440,188.88677 C 259.86587,190.27171 261.42074,191.65282 263.30173,192.16278 C 269.43017,192.63879 275.72611,193.29707 281.33860,196.17671 C 282.95466,195.60625 282.43533,193.42565 281.86509,192.19948 C 280.92708,189.02035 281.58938,185.50698 283.10600,182.65792 C 283.71170,180.98134 281.99124,179.79635 281.22947,178.56343 C 278.48719,175.40101 274.46135,173.56326 270.42625,173.61036 z");
            var head = new Path2D("M 300.94000,103.48119 C 293.21737,101.65805 289.66655,112.27100 283.11632,109.71310 C 273.12764,108.21319 262.26269,118.24611 266.08411,128.44533 C 265.58414,130.41666 256.34910,127.51847 253.21639,131.41265 C 244.51532,136.02828 243.65928,149.54410 251.96956,154.99196 C 258.84582,161.55593 269.34670,156.45284 275.17915,154.77769 C 282.13969,162.42481 292.10171,153.52019 298.37759,160.11490 C 304.75830,164.07236 312.10138,156.93309 315.66900,164.77396 C 320.53096,168.75615 327.29394,167.01981 328.45008,174.37247 C 331.32405,180.02202 340.35416,180.32597 343.64381,181.20886 C 343.47996,191.01069 354.68827,198.37899 363.72979,195.21841 C 366.24653,204.04747 377.08105,208.36351 385.33487,205.00822 C 384.51250,217.48772 400.92286,224.52855 410.60947,217.83948 C 420.78282,213.45915 417.28291,199.11027 413.86960,194.64445 C 422.46335,192.00903 427.17174,180.62601 421.27326,173.27275 C 417.67520,166.09219 406.52031,169.87954 407.53512,160.78479 C 406.01426,154.76518 397.59387,153.08250 394.85018,150.70535 C 398.25288,139.97121 385.23130,130.01899 375.29188,133.69455 C 372.94168,125.72960 363.47066,120.87631 355.62788,123.56717 C 355.10598,112.35192 341.01660,106.23117 331.74413,111.58310 C 327.26815,104.74552 317.43670,102.42441 310.39223,106.60380 C 307.61298,104.71905 304.33184,103.45910 300.94000,103.48119 z");
            var leftEar = new Path2D("M 428.95659,295.54892 C 428.95659,342.66402 423.60779,370.74124 389.32822,370.74124 C 365.20979,370.74124 349.69985,331.48679 349.69985,284.37169 C 349.69985,237.25662 355.04867,199.01826 379.16711,199.01826 C 403.28554,199.01826 428.95659,248.43385 428.95659,295.54892 z");
            var rightNosetril = new Path2D("M 168.79145,260.73637 C 171.01729,263.83128 171.30523,267.76043 172.36782,271.31633 C 173.13399,274.32935 174.50913,277.16999 176.38253,279.64874 C 178.28418,282.50509 179.87000,285.92323 179.20715,289.43754 C 178.79612,292.17539 177.51515,294.98092 175.17929,296.57098 C 173.15973,297.20881 171.73909,295.13634 170.92706,293.59984 C 169.14072,290.34542 169.58981,286.52872 169.18490,282.96903 C 168.90958,279.47579 168.79877,275.96823 168.62593,272.47272 C 168.09045,269.23230 166.55986,265.90491 167.66796,262.61299 C 167.81679,261.91817 167.86807,260.81845 168.79145,260.73637 z");
            var mouth = new Path2D("M 178.54323,311.14831 C 178.88086,319.11796 177.45919,327.29338 179.83035,335.07170 C 181.58660,341.86285 183.56133,348.65806 184.21618,355.66532 C 184.59562,356.64789 183.50746,358.57800 182.80481,356.93191 C 180.60535,349.28609 178.01515,341.68353 177.00632,333.76065 C 176.45364,327.85282 177.63306,321.80307 176.85266,316.00424 C 176.56839,313.89191 178.30811,311.93616 178.49119,310.46113 L 178.50299,310.83214 L 178.54323,311.14831 L 178.54323,311.14831 z");
            var leftNosetril = new Path2D("M 221.35992,274.03577 C 216.28316,275.02415 212.30876,278.58672 207.73286,280.74504 C 204.73408,282.25867 201.46023,283.08063 198.18233,283.72001 C 194.34838,284.67331 190.30593,286.32631 188.14334,289.83695 C 186.66653,292.01885 185.77191,294.82384 186.56063,297.42703 C 187.83987,299.13124 190.27312,298.74891 192.06647,298.26760 C 195.96943,297.35655 198.90438,294.48323 201.84086,291.95217 C 205.39254,289.14318 208.72621,286.07013 212.17473,283.14129 C 215.12329,281.11228 218.80560,279.78670 220.71020,276.56330 C 221.04311,275.80509 222.24567,274.85749 221.35992,274.03577 z");

            ctx.fillRect(445, 460, 20, 100);
            ctx.fillRect(495, 480, 20, 100);
            ctx.fillRect(260, 460, 20, 100);
            ctx.fillRect(310, 480, 20, 100);

            ctx.fillStyle = "white";
            ctx.stroke(body);
            ctx.fill(body);

            ctx.fillStyle = "#faebd7";
            ctx.stroke(rightEar);
            ctx.fill(rightEar);

            ctx.fillStyle = "#eac086";
            ctx.stroke(face);
            ctx.fill(face);

            ctx.fillStyle = "black";
            ctx.stroke(leftEye);
            ctx.fill(leftEye);

            ctx.stroke(rightEye);
            ctx.fill(rightEye);

            ctx.fillStyle = "white";
            ctx.stroke(head);
            ctx.fill(head);

            ctx.fillStyle = "#faebd7";
            ctx.stroke(leftEar);
            ctx.fill(leftEar);

            ctx.fillStyle = "#ffe0bd";
            ctx.fill(rightNosetril);

            ctx.fill(mouth);

            ctx.fill(leftNosetril);
        }
    });
}());