using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuildYourBowl.Data;


namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<IMenuItem> MenuItems { get; set; }
        public IEnumerable<IMenuItem> EntreeItems { get; set; }
        public IEnumerable<IMenuItem> SideItems { get; set; }
        public IEnumerable<IMenuItem> DrinkItems { get; set; }
        public IEnumerable<IMenuItem> KidsMealItems { get; set; }


        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public double? CalorieMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public double? CalorieMax { get; set; }
        
        

        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        public void OnGet()
        {
            MenuItems = Menu.Search(SearchTerms);
            EntreeItems = Menu.EntreeSearch(SearchTerms);
            SideItems = Menu.SideSearch(SearchTerms);
            DrinkItems = Menu.DrinkSearch(SearchTerms);
            KidsMealItems = Menu.KidsMealSearch(SearchTerms);


            EntreeItems = Menu.FilterByCalories(EntreeItems, CalorieMin, CalorieMax);
            EntreeItems = Menu.FilterByPrice(EntreeItems, PriceMin, PriceMax);
            
            SideItems = Menu.FilterByCalories(SideItems, CalorieMin, CalorieMax);
            SideItems = Menu.FilterByPrice(SideItems, PriceMin, PriceMax);
            DrinkItems = Menu.FilterByCalories(DrinkItems, CalorieMin, CalorieMax);
            DrinkItems = Menu.FilterByPrice(DrinkItems, PriceMin, PriceMax);
            KidsMealItems = Menu.FilterByCalories(KidsMealItems, CalorieMin, CalorieMax);
            KidsMealItems = Menu.FilterByPrice(KidsMealItems, PriceMin, PriceMax);
            

            //MenuItems = Menu.FilterByCalorie(MenuItems, CalorieRatings);
        }
    }
}
