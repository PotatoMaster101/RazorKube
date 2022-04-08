using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorKube.DataAccess;

namespace RazorKube.Web.Pages;

public class DbCheckModel : PageModel
{
    private readonly IDataAccess _dataAccess;

    public string DbTables { get; private set; } = string.Empty;

    public string DbVersion { get; private set; } = string.Empty;

    public DbCheckModel(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task OnGetAsync()
    {
        DbTables = await _dataAccess.ExecuteSql<string>("SELECT table_name FROM information_schema.tables;");
        DbVersion = await _dataAccess.ExecuteSql<string>("SELECT version();");
    }
}
