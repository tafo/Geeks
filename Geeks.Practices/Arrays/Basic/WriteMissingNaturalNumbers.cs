using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "First K natural numbers"
    /// 
    /// Given an array of size n and a number k, we need to print first k natural numbers that are not there in given array.
    /// 
    /// Input:
    /// First line consists of T test case.
    /// First line of every test case consists of N and K.
    /// Second line consists of elements of array.
    /// 
    /// Output:
    /// Single line output, print the K missing numbers.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=N<=10^4
    /// -1000<=Ai<=1000
    /// 
    /// Example:
    ///
    /// Input:
    /// 3
    /// 3 3
    /// 1 4 3
    /// 3 3
    /// -5 -6 1
    /// 384 887
    /// -223 -85 793 -665 386 -508 -351 421 -638 -973 -310 -941 763 926 -460 426 172 736 211 368 -433 -571 782 530 -138 123 -933 135 929 802 -978 58 69 -833 393 -544 11 -958 -771 373 -579 -81 784 -463 198 -676 -685 -630 -587 526 -909 -20 956 873 -138 170 -4 281 -695 -75 84 -673 -664 -495 -154 729 313 857 -876 895 582 -455 -186 367 434 -636 -957 750 87 -192 276 178 788 584 403 -349 -246 -601 932 60 676 368 739 -988 -774 -414 -906 539 -205 -430 434 -622 467 -399 -903 -98 317 -508 -348 -244 301 -720 -714 441 865 689 -556 -381 -560 -271 -969 -883 -903 771 -519 -325 -291 -73 -433 856 497 -647 -414 -35 306 -317 -781 -376 528 -129 732 -171 503 -981 -730 368 708 -285 -660 -851 796 -277 -382 -755 -154 451 -79 555 -621 488 764 -772 841 -650 193 500 34 764 -876 -86 -13 856 743 -509 -773 -635 859 936 432 -449 -563 228 275 407 474 -879 -142 -605 -971 237 -765 793 818 -572 -857 11 928 529 -224 -596 -557 763 -387 -462 -394 -160 -96 -182 128 -312 369 917 917 -4 324 743 470 -817 -510 499 772 -275 644 590 505 -861 -46 786 669 -918 -458 -536 -803 507 355 -196 -652 -389 622 828 299 343 746 568 -660 422 311 810 605 801 661 730 -122 305 320 -264 444 -374 -478 465 -292 416 -718 258 -76 637 -938 624 -400 -964 452 899 379 550 468 -929 -27 131 881 -70 -67 894 -340 -837 199 981 -101 -4 -41 773 -187 668 190 95 -74 -534 84 340 -910 684 376 542 936 107 445 756 179 -582 -113 412 348 -828 659 -991 -664 210 -658 587 -794 301 713 372 321 255 -181 -401 721 904 939 811 940 667 705 -772 127 150 984 -342 920 224 -578 269 396 -919 630 -916 292 972 672 850 625 385 222 299 -360 -958 898 -287 -702 -810 -476 -410 -791 -419 -181 336 732 155 994 -996 -621 -231 273 776 -150 255 860 -858 579 884 993 205 621 567
    /// 
    /// Output:
    /// 2 5 6 
    /// 2 3 4
    /// 1 2 3 4 5 6 7 8 9 10 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 59 61 62 63 64 65 66 67 68 70 71 72 73 74 75 76 77 78 79 80 81 82 83 85 86 88 89 90 91 92 93 94 96 97 98 99 100 101 102 103 104 105 106 108 109 110 111 112 113 114 115 116 117 118 119 120 121 122 124 125 126 129 130 132 133 134 136 137 138 139 140 141 142 143 144 145 146 147 148 149 151 152 153 154 156 157 158 159 160 161 162 163 164 165 166 167 168 169 171 173 174 175 176 177 180 181 182 183 184 185 186 187 188 189 191 192 194 195 196 197 200 201 202 203 204 206 207 208 209 212 213 214 215 216 217 218 219 220 221 223 225 226 227 229 230 231 232 233 234 235 236 238 239 240 241 242 243 244 245 246 247 248 249 250 251 252 253 254 256 257 259 260 261 262 263 264 265 266 267 268 270 271 272 274 277 278 279 280 282 283 284 285 286 287 288 289 290 291 293 294 295 296 297 298 300 302 303 304 307 308 309 310 312 314 315 316 318 319 322 323 .................
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class WriteMissingNaturalNumbers
    {
        /// <summary>
        /// The execution time is 0.15
        /// </summary>
        public static void RunMix()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            // 3 5 9
            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetInt(test[1], n);
                Array.Sort(numbers);
                Console.WriteLine(string.Join(' ', Enumerable.Range(1, 2 * n).Except(numbers).Take(k)));
            }
        }

        /// <summary>
        /// The execution time is 0.11
        /// </summary>
        public static void RunLoop()
        {
            var testCount = int.Parse(Console.ReadLine());
            var tests = new string[testCount][];

            for (var i = 0; i < testCount; i++)
            {
                tests[i] = new string[2];
                tests[i][0] = Console.ReadLine();
                tests[i][1] = Console.ReadLine().TrimEnd();
            }

            foreach (var test in tests)
            {
                var split = test[0].Split(' ');
                var n = int.Parse(split[0]);
                var k = int.Parse(split[1]);
                var numbers = StringScanner.GetInt(test[1], n);
                Array.Sort(numbers);
                var result = new int[k];
                var r = 0;
                var current = 1;
                var i = 0;
                while (r < k)
                {
                    if (i == n || numbers[i] > current)
                    {
                        result[r++] = current++;
                    }
                    else if (numbers[i] == current)
                    {
                        i++;
                        current++;
                    }
                    else
                    {
                        i++;
                    }
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}