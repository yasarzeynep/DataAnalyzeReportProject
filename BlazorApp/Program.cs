using Business;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IExcelService, ExcelService>();
builder.Services.AddHttpClient<ILinkService, LinkService>();

// EPPlus lisans baðlamýný belirleme
ExcelPackage.LicenseContext = LicenseContext.Commercial;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
