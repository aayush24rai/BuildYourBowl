using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class ReviewsModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            ReviewDatabase.AddReview(ReviewText, DateTime.Now ); //Check if it is supposed to be DateTime.Now
            ReviewText = null;
        }


        [BindProperty]
        public string? ReviewText { get; set; }

        //public IEnumerable<Review> AllReviews => ReviewDatabase.Reviews;
        public IEnumerable<Review> AllReviews => ReviewDatabase.Reviews.OrderByDescending(review => review.PlacedAt);

    }
}
