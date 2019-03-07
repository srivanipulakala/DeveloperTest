using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Should_output_invalid_usage_message()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new []{"-a"});

                Assert.IsTrue(sw.ToString().StartsWith("Error : invalid usage"));
            }
        }

        [TestMethod]
        public void Should_output_valid_file_version()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { "-v", "sample.txt" });

                var output = sw.ToString().Replace(Environment.NewLine, "");
                var isValidVersion = Regex.IsMatch(output, "^\\d{1}\\.\\d{1}.\\d{1,2}$");

                Assert.IsTrue(isValidVersion);
            }
        }

        [TestMethod]
        public void Should_output_valid_file_size()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { "-s", "sample.txt" });

                var output = Convert.ToInt32(sw.ToString().Replace(Environment.NewLine, ""));

                Assert.IsTrue(output >= 100000);
            }
        }
    }
}
