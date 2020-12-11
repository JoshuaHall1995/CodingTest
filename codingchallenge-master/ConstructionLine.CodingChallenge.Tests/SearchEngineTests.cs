using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        public void GetASingleShirtMatches_AndSizeIsNotSupplied_ReturnTheShirt()
        {
            var shirts = BuildBaseShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size>()
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void GetASingleShirtMatches_AndColorIsNotSupplied_ReturnTheShirt()
        {
            var shirts = BuildBaseShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> (),
                Sizes = new List<Size> {Size.Small}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void GetASingleShirtMatches_AndSizeAndColorAreSupplied_ReturnTheShirt()
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
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
        }
        

        [Test]
        public void GivenASingleShirtToReturn_ButMultipleSizeOptionsSupplied_ReturnOneShirt()
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
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void GivenASingleShirtToReturn_ButMultipleColorOptionsSupplied_ReturnOneShirt()
        {
            var shirts = BuildBaseShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red, Color.Black},
                Sizes = new List<Size> {Size.Medium}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void GivenMultipleShirtsRoReturn_ReturnTwoShirt()
        {
            var shirts = BuildBaseShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red, Color.Black},
                Sizes = new List<Size> {Size.Small, Size.Medium}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
        }

        [Test]
        public void GetNoMatchingShirt_AndSizeAndColorAreSupplied_ReturnNoShirts()
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
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
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
