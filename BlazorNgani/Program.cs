using BlazorNgani.Admin;
using BlazorNgani.Admin.Components.Services;
using BlazorNgani.Components;
using BlazorNgani.Components.OverView;
using BlazorNgani.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "Google";
})
    .AddCookie("Cookies")
    .AddGoogle(options =>
    {
        options.ClientId = "631672100001-bc07thrnb5p03gfbt5bp36ol3st897il.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AdminLayout>();
builder.Services.AddAuthorization(Options =>
Options.AddPolicy("AdminOnly", policy =>
policy.RequireRole("Admin")));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
