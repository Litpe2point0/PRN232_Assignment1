using BusinessObject.Entities;
using FUNewsManagementSystem.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;


namespace FUNewsManagementSystem.Pages.Tags
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        private readonly IHubContext<SignalrServer> _hubContext;
        public CreateModel(HttpClient httpClient, IHubContext<SignalrServer> hubContext)
        {
            _httpClient = httpClient;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tag Tag { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Lấy TagId lớn nhất và +1
                var maxId = (await _httpClient.GetFromJsonAsync<int?>("https://localhost:7126/api/Tag/MaxId")) ?? 0;
                Tag.TagId = maxId + 1;

                await _httpClient.PostAsJsonAsync("https://localhost:7126/api/Tag", Tag);
                await _hubContext.Clients.All.SendAsync("LoadAllItems");

                return RedirectToPage("./Index");
            }

            return Page();
          
        }
    }
}
