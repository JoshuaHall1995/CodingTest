using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        // MultipleShirtsToFind
        
        // MultipleSizesOneColour
        
        // MultipleCloursOneSize
        
        
        [Test]
        public void GetASingleShirt()
        {
            var shirts = BuildBaseShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void GivenMultipleSearchOptions_MoreThenOneShirtShouldBeReturned()
        {
            var shirts = BuildBaseShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small, Size.Medium}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
        }

        [Test] 
        public void ShirtDoesNotExist()
        {
            var shirts = new List<Shirt>();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.White},
                Sizes = new List<Size> {Size.Large}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
        }
        
        private static List<Shirt> BuildBaseShirts()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };
            return shirts;
        }
    }
}
