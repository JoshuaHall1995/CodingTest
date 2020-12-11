using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
        }


        public SearchResults Search(SearchOptions options)
        {
            var matchingShirts = FindMatchingShirts(options);
            var sizeList = MapSizes(matchingShirts);
            var colorList = MapColours(matchingShirts);

            return new SearchResults
            {
                Shirts = matchingShirts,
                SizeCounts = sizeList,
                ColorCounts = colorList
            };
        }

        private static List<SizeCount> MapSizes(IEnumerable<Shirt> matchingShirts)
        {
            var sizeList = new List<SizeCount>();

            var returnedSizes = matchingShirts.Select(x => x.Size)
                .GroupBy(x => x.Name).Select(group => new
                {
                    Size = @group.Key,
                    Count = @group.Count()
                }).ToList();

            // Could be a Linq statement as well but for readability this was avoided
            // return Size.All.Select(size => new SizeCount {Size = size, Count = returnedSizes.Where(x => x.Size == size.Name).Select(x => x.Count).SingleOrDefault()}).ToList();

            foreach (var size in Size.All)
            {
                sizeList.Add(new SizeCount
                {
                    Size = size,
                    Count = returnedSizes.Where(x => x.Size == size.Name).Select(x => x.Count).SingleOrDefault()
                });
            }

            return sizeList;
        }

        private static List<ColorCount> MapColours(IEnumerable<Shirt> matchingShirts)
        {
            var colorList = new List<ColorCount>();

            var returnedColours = matchingShirts.Select(x => x.Color)
                .GroupBy(x => x.Name).Select(group => new
                {
                    Color = @group.Key,
                    Count = @group.Count()
                }).ToList();

            foreach (var color in Color.All)
            {
                colorList.Add(new ColorCount
                {
                    Color = color,
                    Count = returnedColours.Where(x => x.Color == color.Name).Select(x => x.Count).SingleOrDefault()
                });
            }

            return colorList;
        }

        private List<Shirt> FindMatchingShirts(SearchOptions options)
        {
            var filteredSizeOrders = options.Sizes.Any() ? _shirts.Where(o => options.Sizes.Contains(o.Size)) : _shirts;
            var matchingShirts = options.Colors.Any() ? _shirts.Where(o => options.Colors.Contains(o.Color)) : filteredSizeOrders;
            return matchingShirts.ToList();
        }
    }
}