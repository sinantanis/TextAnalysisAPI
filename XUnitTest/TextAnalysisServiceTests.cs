using Xunit;
using TextAnalysisApi.Services;
using TextAnalysisAPI.Interfaces;

namespace TextAnalysisApi.Tests
{
    public class TextAnalysisServiceTests
    {
        private readonly ITextAnalysisService _service;

        public TextAnalysisServiceTests()
        {
            _service = new TextAnalysisService();
        }

        // DE: Tests für jede Methode des TextAnalysisService
        [Fact]
        public void CountWords_ShouldReturnCorrectCounts()
        {
            var result = _service.CountWords("This is a test string", new[] { "is", "test", "not" });
            Assert.Equal(1, result["is"]);
            Assert.Equal(1, result["test"]);
            Assert.Equal(0, result["not"]);
        }

        [Fact]
        public void CountWords_WithEmptyInput_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _service.CountWords("", new[] { "test" }));
        }

        [Fact]
        public void CheckWords_ShouldReturnCorrectPresence()
        {
            var result = _service.CheckWords("This is a test string", new[] { "is", "test", "not" });
            Assert.True(result["is"]);
            Assert.True(result["test"]);
            Assert.False(result["not"]);
        }

        [Fact]
        public void CountLetters_ShouldReturnCorrectCounts()
        {
            var result = _service.CountLetters("This is a test string", new[] { 't', 'i', 'x' });
            Assert.Equal(4, result['t']);
            Assert.Equal(3, result['i']);
            Assert.Equal(0, result['x']);
        }

        [Fact]
        public void CheckLetters_ShouldReturnCorrectPresence()
        {
            var result = _service.CheckLetters("This is a test string", new[] { 't', 'i', 'x' });
            Assert.True(result['t']);
            Assert.True(result['i']);
            Assert.False(result['x']);
        }

        [Fact]
        public void IsBase64_ShouldReturnCorrectResult()
        {
            Assert.True(_service.IsBase64("SGVsbG8gV29ybGQ="));
            Assert.False(_service.IsBase64("This is not base64"));
        }

        [Fact]
        public void IsEmail_ShouldReturnCorrectResult()
        {
            Assert.True(_service.IsEmail("test@example.com"));
            Assert.False(_service.IsEmail("not an email"));
        }

        [Fact]
        public void IsEmail_WithInvalidFormat_ShouldReturnFalse()
        {
            Assert.False(_service.IsEmail("test@example"));
            Assert.False(_service.IsEmail("test@.com"));
            Assert.False(_service.IsEmail("@example.com"));
        }
    }
}