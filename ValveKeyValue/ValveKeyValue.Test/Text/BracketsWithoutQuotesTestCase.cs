using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ValveKeyValue.Test
{
    class BracketsWithoutQuotesTestCase
    {
        [Test]
        public void CorrectlyAssumesBracketedValueIsAString()
        {
            Assert.That((string)data["$envmapsaturation"], Is.EqualTo("[.5 .5 .5]"));
        }

        KVObject data;

        [OneTimeSetUp]
        public void SetUp()
        {
            var options = new KVSerializerOptions { HasEscapeSequences = true };
            using (var stream = TestDataHelper.OpenResource("Text.brackets_without_quotes.vdf"))
            {
                data = KVSerializer.Create(KVSerializationFormat.KeyValues1Text).Deserialize(stream, options);
            }
        }
    }
}
