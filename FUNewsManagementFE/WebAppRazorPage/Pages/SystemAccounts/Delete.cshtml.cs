using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace FUNewsManagementSystem.Pages.SystemAccounts
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnPostAsync(short id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7126/api/SystemAccount/{id}");
            return RedirectToPage("/SystemAccounts/Index");
        }
    }
}
