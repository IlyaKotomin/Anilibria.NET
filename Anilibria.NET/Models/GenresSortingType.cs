namespace Anilibria.NET.Models
{
    /// <summary>
    /// Sorting received genres from AnilibriaAPI.GetGenresAsync();
    /// </summary>
    public enum GenresSortingType
    {
        /// <summary>
        /// Sorting by alphabet
        /// </summary>
        ByAlphabet,

        /// <summary>
        /// Sorting by popularity
        /// </summary>
        ByPopularity
    }
}
