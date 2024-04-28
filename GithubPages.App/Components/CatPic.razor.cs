using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using GithubPages.App.Components.Models;
using Microsoft.AspNetCore.Components;

namespace GithubPages.App.Components;

public partial class CatPic
{
    private const string BaseUrl = "https://cataas.com/cat";

    public int Width { get; set; } = 400;
    public int Height { get; set; } = 300;

    [Inject]
    private HttpClient Client { get; set; } = default!;

    [Parameter]
    public string? Text { get; set; }

    [MemberNotNullWhen(true, nameof(CatPicUrl))]
    public bool HasCatPic { get; set; }

    public string? CatPicUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var cat = await Client.GetFromJsonAsync<Cat>(BaseUrl + "?json=true");

        if (cat is not null)
        {
            HasCatPic = true;
            CatPicUrl = $"{BaseUrl}/{cat.Id}?width={Width}&height={Height}";

            Console.WriteLine(CatPicUrl);
        }
    }
}
