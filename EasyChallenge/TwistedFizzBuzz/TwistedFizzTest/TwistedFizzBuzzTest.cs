using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using System.Collections.Generic;
using System.Linq;

namespace TwistedFizzTest
{
    [TestClass]
    public class TwistedFizzBuzzTest
    {
        TwistedFizzBuzz.TwistedFizzBuzz twisted = new TwistedFizzBuzz.TwistedFizzBuzz();

        [TestMethod]
        public void OriginalFizzProblemTest()
        {
            string originalProblemResult = "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz,16,17,Fizz,19,Buzz,Fizz,22,23,Fizz,Buzz,26,Fizz,28,29,FizzBuzz,31,32,Fizz,34,Buzz,Fizz,37,38,Fizz,Buzz,41,Fizz,43,44,FizzBuzz,46,47,Fizz,49,Buzz,Fizz,52,53,Fizz,Buzz,56,Fizz,58,59,FizzBuzz,61,62,Fizz,64,Buzz,Fizz,67,68,Fizz,Buzz,71,Fizz,73,74,FizzBuzz,76,77,Fizz,79,Buzz,Fizz,82,83,Fizz,Buzz,86,Fizz,88,89,FizzBuzz,91,92,Fizz,94,Buzz,Fizz,97,98,Fizz,Buzz";
            
            List<string> expectedResult = originalProblemResult.Split(',').ToList();

            List<string> originalFizzProblemResult = twisted.OriginalFizzProblem();

            CollectionAssert.AreEqual(expectedResult, originalFizzProblemResult);

        }

        [TestMethod]
        public void NonSequentialSetOfNumbersTest()
        {
            string expectedStringResult = "1,Fizz,Buzz,Fizz,7,FizzBuzz,Fizz,Fizz,FizzBuzz,Fizz,89,FizzBuzz";
            List<string> expectedResult = expectedStringResult.Split(',').ToList();

            int[] nonSequentialSequece = new int[] {1, 3, 5, 6, 7, 45, 3, 12, 15, 87, 89, 90 };

            List<string> nonSequentialSetResult = twisted.NonSequentialSetOfNumbers(nonSequentialSequece);

            CollectionAssert.AreEqual(expectedResult, nonSequentialSetResult);
        }

        [TestMethod]
        public void RangeOfNumbersTest()
        {
            string expectedStringResult = "Buzz,Fizz,-188,-187,Fizz,Buzz,-184,Fizz,-182,-181,FizzBuzz,-179,-178,Fizz,-176,Buzz,Fizz,-173,-172,Fizz,Buzz,-169,Fizz,-167,-166,FizzBuzz,-164,-163,Fizz,-161,Buzz,Fizz,-158,-157,Fizz,Buzz,-154,Fizz,-152,-151,FizzBuzz,-149,-148,Fizz,-146,Buzz,Fizz,-143,-142,Fizz,Buzz,-139,Fizz,-137,-136,FizzBuzz,-134,-133,Fizz,-131,Buzz,Fizz,-128,-127,Fizz,Buzz,-124,Fizz,-122,-121,FizzBuzz,-119,-118,Fizz,-116,Buzz,Fizz,-113,-112,Fizz,Buzz,-109,Fizz,-107,-106,FizzBuzz,-104,-103,Fizz,-101,Buzz,Fizz,-98,-97,Fizz,Buzz,-94,Fizz,-92,-91,FizzBuzz,-89,-88,Fizz,-86,Buzz,Fizz,-83,-82,Fizz,Buzz,-79,Fizz,-77,-76,FizzBuzz,-74,-73,Fizz,-71,Buzz,Fizz,-68,-67,Fizz,Buzz,-64,Fizz,-62,-61,FizzBuzz,-59,-58,Fizz,-56,Buzz,Fizz,-53,-52,Fizz,Buzz,-49,Fizz,-47,-46,FizzBuzz,-44,-43,Fizz,-41,Buzz,Fizz,-38,-37,Fizz,Buzz,-34,Fizz,-32,-31,FizzBuzz,-29,-28,Fizz,-26,Buzz,Fizz,-23,-22,Fizz,Buzz,-19,Fizz,-17,-16,FizzBuzz,-14,-13,Fizz,-11,Buzz,Fizz,-8,-7,Fizz,Buzz,-4,Fizz,-2,-1,FizzBuzz,1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz,16,17,Fizz,19,Buzz,Fizz,22,23,Fizz,Buzz,26,Fizz,28,29,FizzBuzz,31,32,Fizz,34,Buzz,Fizz,37,38,Fizz,Buzz,41,Fizz,43,44,FizzBuzz,46,47,Fizz,49,Buzz,Fizz,52,53,Fizz,Buzz,56,Fizz,58,59,FizzBuzz,61,62,Fizz,64,Buzz,Fizz,67,68,Fizz,Buzz,71,Fizz,73,74,FizzBuzz,76,77,Fizz,79,Buzz,Fizz,82,83,Fizz,Buzz,86,Fizz,88,89,FizzBuzz";
            List<string> expectedResult = expectedStringResult.Split(',').ToList();

            List<string> nonSequentialSetResult = twisted.RangeOfNumbers(90, -190);

            CollectionAssert.AreEqual(expectedResult, nonSequentialSetResult);

            List<string> nonSequentialSetResultWithDifferentValues = twisted.RangeOfNumbers(-999, -250);

            expectedStringResult = "Fizz,-998,-997,Fizz,Buzz,-994,Fizz,-992,-991,FizzBuzz,-989,-988,Fizz,-986,Buzz,Fizz,-983,-982,Fizz,Buzz,-979,Fizz,-977,-976,FizzBuzz,-974,-973,Fizz,-971,Buzz,Fizz,-968,-967,Fizz,Buzz,-964,Fizz,-962,-961,FizzBuzz,-959,-958,Fizz,-956,Buzz,Fizz,-953,-952,Fizz,Buzz,-949,Fizz,-947,-946,FizzBuzz,-944,-943,Fizz,-941,Buzz,Fizz,-938,-937,Fizz,Buzz,-934,Fizz,-932,-931,FizzBuzz,-929,-928,Fizz,-926,Buzz,Fizz,-923,-922,Fizz,Buzz,-919,Fizz,-917,-916,FizzBuzz,-914,-913,Fizz,-911,Buzz,Fizz,-908,-907,Fizz,Buzz,-904,Fizz,-902,-901,FizzBuzz,-899,-898,Fizz,-896,Buzz,Fizz,-893,-892,Fizz,Buzz,-889,Fizz,-887,-886,FizzBuzz,-884,-883,Fizz,-881,Buzz,Fizz,-878,-877,Fizz,Buzz,-874,Fizz,-872,-871,FizzBuzz,-869,-868,Fizz,-866,Buzz,Fizz,-863,-862,Fizz,Buzz,-859,Fizz,-857,-856,FizzBuzz,-854,-853,Fizz,-851,Buzz,Fizz,-848,-847,Fizz,Buzz,-844,Fizz,-842,-841,FizzBuzz,-839,-838,Fizz,-836,Buzz,Fizz,-833,-832,Fizz,Buzz,-829,Fizz,-827,-826,FizzBuzz,-824,-823,Fizz,-821,Buzz,Fizz,-818,-817,Fizz,Buzz,-814,Fizz,-812,-811,FizzBuzz,-809,-808,Fizz,-806,Buzz,Fizz,-803,-802,Fizz,Buzz,-799,Fizz,-797,-796,FizzBuzz,-794,-793,Fizz,-791,Buzz,Fizz,-788,-787,Fizz,Buzz,-784,Fizz,-782,-781,FizzBuzz,-779,-778,Fizz,-776,Buzz,Fizz,-773,-772,Fizz,Buzz,-769,Fizz,-767,-766,FizzBuzz,-764,-763,Fizz,-761,Buzz,Fizz,-758,-757,Fizz,Buzz,-754,Fizz,-752,-751,FizzBuzz,-749,-748,Fizz,-746,Buzz,Fizz,-743,-742,Fizz,Buzz,-739,Fizz,-737,-736,FizzBuzz,-734,-733,Fizz,-731,Buzz,Fizz,-728,-727,Fizz,Buzz,-724,Fizz,-722,-721,FizzBuzz,-719,-718,Fizz,-716,Buzz,Fizz,-713,-712,Fizz,Buzz,-709,Fizz,-707,-706,FizzBuzz,-704,-703,Fizz,-701,Buzz,Fizz,-698,-697,Fizz,Buzz,-694,Fizz,-692,-691,FizzBuzz,-689,-688,Fizz,-686,Buzz,Fizz,-683,-682,Fizz,Buzz,-679,Fizz,-677,-676,FizzBuzz,-674,-673,Fizz,-671,Buzz,Fizz,-668,-667,Fizz,Buzz,-664,Fizz,-662,-661,FizzBuzz,-659,-658,Fizz,-656,Buzz,Fizz,-653,-652,Fizz,Buzz,-649,Fizz,-647,-646,FizzBuzz,-644,-643,Fizz,-641,Buzz,Fizz,-638,-637,Fizz,Buzz,-634,Fizz,-632,-631,FizzBuzz,-629,-628,Fizz,-626,Buzz,Fizz,-623,-622,Fizz,Buzz,-619,Fizz,-617,-616,FizzBuzz,-614,-613,Fizz,-611,Buzz,Fizz,-608,-607,Fizz,Buzz,-604,Fizz,-602,-601,FizzBuzz,-599,-598,Fizz,-596,Buzz,Fizz,-593,-592,Fizz,Buzz,-589,Fizz,-587,-586,FizzBuzz,-584,-583,Fizz,-581,Buzz,Fizz,-578,-577,Fizz,Buzz,-574,Fizz,-572,-571,FizzBuzz,-569,-568,Fizz,-566,Buzz,Fizz,-563,-562,Fizz,Buzz,-559,Fizz,-557,-556,FizzBuzz,-554,-553,Fizz,-551,Buzz,Fizz,-548,-547,Fizz,Buzz,-544,Fizz,-542,-541,FizzBuzz,-539,-538,Fizz,-536,Buzz,Fizz,-533,-532,Fizz,Buzz,-529,Fizz,-527,-526,FizzBuzz,-524,-523,Fizz,-521,Buzz,Fizz,-518,-517,Fizz,Buzz,-514,Fizz,-512,-511,FizzBuzz,-509,-508,Fizz,-506,Buzz,Fizz,-503,-502,Fizz,Buzz,-499,Fizz,-497,-496,FizzBuzz,-494,-493,Fizz,-491,Buzz,Fizz,-488,-487,Fizz,Buzz,-484,Fizz,-482,-481,FizzBuzz,-479,-478,Fizz,-476,Buzz,Fizz,-473,-472,Fizz,Buzz,-469,Fizz,-467,-466,FizzBuzz,-464,-463,Fizz,-461,Buzz,Fizz,-458,-457,Fizz,Buzz,-454,Fizz,-452,-451,FizzBuzz,-449,-448,Fizz,-446,Buzz,Fizz,-443,-442,Fizz,Buzz,-439,Fizz,-437,-436,FizzBuzz,-434,-433,Fizz,-431,Buzz,Fizz,-428,-427,Fizz,Buzz,-424,Fizz,-422,-421,FizzBuzz,-419,-418,Fizz,-416,Buzz,Fizz,-413,-412,Fizz,Buzz,-409,Fizz,-407,-406,FizzBuzz,-404,-403,Fizz,-401,Buzz,Fizz,-398,-397,Fizz,Buzz,-394,Fizz,-392,-391,FizzBuzz,-389,-388,Fizz,-386,Buzz,Fizz,-383,-382,Fizz,Buzz,-379,Fizz,-377,-376,FizzBuzz,-374,-373,Fizz,-371,Buzz,Fizz,-368,-367,Fizz,Buzz,-364,Fizz,-362,-361,FizzBuzz,-359,-358,Fizz,-356,Buzz,Fizz,-353,-352,Fizz,Buzz,-349,Fizz,-347,-346,FizzBuzz,-344,-343,Fizz,-341,Buzz,Fizz,-338,-337,Fizz,Buzz,-334,Fizz,-332,-331,FizzBuzz,-329,-328,Fizz,-326,Buzz,Fizz,-323,-322,Fizz,Buzz,-319,Fizz,-317,-316,FizzBuzz,-314,-313,Fizz,-311,Buzz,Fizz,-308,-307,Fizz,Buzz,-304,Fizz,-302,-301,FizzBuzz,-299,-298,Fizz,-296,Buzz,Fizz,-293,-292,Fizz,Buzz,-289,Fizz,-287,-286,FizzBuzz,-284,-283,Fizz,-281,Buzz,Fizz,-278,-277,Fizz,Buzz,-274,Fizz,-272,-271,FizzBuzz,-269,-268,Fizz,-266,Buzz,Fizz,-263,-262,Fizz,Buzz,-259,Fizz,-257,-256,FizzBuzz,-254,-253,Fizz,-251,Buzz";

            expectedResult = expectedStringResult.Split(',').ToList();
            
            CollectionAssert.AreEqual(expectedResult, nonSequentialSetResultWithDifferentValues);
        }
    }
}
