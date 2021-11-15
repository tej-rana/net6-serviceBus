using Microsoft.AspNetCore.Authentication;
using TangoRestaurant.Web;
using TangoRestaurant.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>();
ServiceLocator.ProductApiBase = builder.Configuration["ServiceUrls:ProductApi"];
ServiceLocator.ShoppingCartApiBase = builder.Configuration["ServiceUrls:ShoppingCartApi"];
ServiceLocator.CouponApiBase = builder.Configuration["ServiceUrls:CouponApiBase"];
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICouponService, CouponService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
               .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
              
               .AddOpenIdConnect("oidc", options =>
               {
                   options.Authority = builder.Configuration["ServiceUrls:IdentityApi"];
                   options.GetClaimsFromUserInfoEndpoint = true;
                   options.ClientId = "tango_client";
                   options.ClientSecret = "secret";
                   options.ResponseType = "code";
                   options.ClaimActions.MapJsonKey("role", "role", "role");
                   options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                   options.TokenValidationParameters.NameClaimType = "name";
                   options.TokenValidationParameters.RoleClaimType = "role";
                   options.Scope.Add("tango");
                   options.SaveTokens = true;

               });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
