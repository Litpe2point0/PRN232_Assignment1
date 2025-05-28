using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FUNewsManagementSystem.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace FUNewsManagementSystem.Pages.NewsArticles
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHubContext<SignalrServer> _hubContext;
        public DeleteModel(HttpClient httpClient, IHubContext<SignalrServer> hubContext)
        {
            _httpClient = httpClient;
            _hubContext = hubContext;
        }



        public async Task<IActionResult> OnPostAsync(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7126/api/NewsArticle/{id}");
            await _hubContext.Clients.All.SendAsync("LoadAllArticles");
            return RedirectToPage("/NewsArticles/Index");
        }
    }
}
