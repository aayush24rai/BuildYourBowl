using Newtonsoft.Json;

namespace Website
{
    public static class ReviewDatabase
    {
        private static List<Review> _reviews;

        static ReviewDatabase()
        {
            if (File.Exists("reviews.json"))
            {
                string json = File.ReadAllText("review.json");

                _reviews = JsonConvert.DeserializeObject<List<Review>>(json)!;
            }

            if (_reviews == null)
            {
                _reviews = new List<Review>();
            }
        }

        public static IEnumerable<Review> Reviews => _reviews;

        public static void AddReview(string n, DateTime d)
        {
            if (n != null && n != "")
            {
                _reviews.Add(new Review() { Text = n, PlacedAt = d});

                File.WriteAllText("reviews.json", JsonConvert.SerializeObject(Reviews));
            }
        }
    }
}
