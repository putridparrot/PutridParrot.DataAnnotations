using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;
using PutridParrot.DataAnnotations;

namespace Tests.PutridParrot.DataAnnotations
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ExpectedAttributeTests
    {
        [Test]
        public void GenerateMessage_False_ExpectNull()
        {
            var attr = new ExpectedAttribute(new [] { "Danger", "Mouse" });

            attr.IsValid("Penfold");
            attr.ErrorMessage
                .Should()
                .BeNull();
        }

        [Test]
        public void GenerateMessage_True_ExpectNonNull()
        {
            var attr = new ExpectedAttribute(new[] { "Danger", "Mouse" }, true);

            attr.IsValid("Penfold");
            attr.ErrorMessage
                .Should()
                .NotBeNull();
        }

        [Test]
        public void IsValid_NotValid_ExpectFalse()
        {
            var attr = new ExpectedAttribute(new[] { "Danger", "Mouse" }, true);

            attr.IsValid("Penfold")
                .Should()
                .BeFalse();
        }

        [Test]
        public void IsValid_IsValid_ExpectFalse()
        {
            var attr = new ExpectedAttribute(new[] { "Danger", "Mouse" }, true);

            attr.IsValid("Mouse")
                .Should()
                .BeTrue();
        }
    }
}
