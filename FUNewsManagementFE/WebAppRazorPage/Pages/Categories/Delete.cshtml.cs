using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FUNewsManagementSystem.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnPostAsync(short id)
        {
            try
            {
                await _httpClient.DeleteAsync($"https://localhost:7126/api/Category/{id}");
                return new JsonResult(new { success = true, message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Error: " + ex.Message });
            }
        }

    }
}
