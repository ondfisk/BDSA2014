using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PolishCalculator.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Calculate_null_returns_0()
        {
            const string input = null;

            var result = Program.Calculate(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Calculate_EmptyString_returns_0()
        {
            var input = string.Empty;

            var result = Program.Calculate(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Calculate_WhiteSpace_returns_0()
        {
            const string input = "  ";

            var result = Program.Calculate(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Calculate_42_returns_42()
        {
            const string input = "42";

            var result = Program.Calculate(input);

            Assert.AreEqual(42, result);
        }


        [Test]
        public void Calculate_5_5_Add_equals_10()
        {
            const string input = "5 5 +";

            var result = Program.Calculate(input);

            Assert.AreEqual(10, result);
        }

        [Test]
        public void Calculate_5_5_2_Multiply_Add_equals_15()
        {
            const string input = "5 5 2 * +";

            var result = Program.Calculate(input);

            Assert.AreEqual(15, result);
        }

        [Test]
        public void Calculate_1_2_Add_4_Multiply_5_Add_3_Subtract_equals_14()
        {
            const string input = "1 2 + 4 * 5 + 3 -";

            var result = Program.Calculate(input);

            Assert.AreEqual(14, result);
        }

        [Test]
        public void Calculate_84_2_Divide_equals_42()
        {
            const string input = "84 2 /";

            var result = Program.Calculate(input);

            Assert.AreEqual(42, result);
        }

        [Test]
        public void Calculate_42_infinity_throws()
        {
            const string input = "42 infinity";

            Assert.Throws<InvalidOperationException>(() => Program.Calculate(input));
        }
    }
}
