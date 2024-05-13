using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using GithubPages.App.Components.Models;
using Microsoft.AspNetCore.Components;

namespace GithubPages.App.Components;

public partial class CatPic : ComponentBase
{
    private const string BaseUrl = "https://cataas.com/cat";

    public int Width { get; } = 400;
    public int Height { get; } = 400;
    public string[] Tags { get; set; } = [];

    [Inject]
    private HttpClient Client { get; set; } = default!;

    [Parameter]
    public string? Text { get; set; }

    [MemberNotNullWhen(true, nameof(CatUrl))]
    public bool IsLoaded { get; set; }

    public string? CatUrl { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        var cat = await Client.GetFromJsonAsync<Cat>(BaseUrl + "?json=true");

        if (cat is not null)
        {
            IsLoaded = true;
            CatUrl = $"{BaseUrl}/{cat.Id}?width={Width}&height={Height}";

            if (cat.Tags?.Length > 0)
            {
                Tags = cat.Tags;
            }
        }
    }
}
