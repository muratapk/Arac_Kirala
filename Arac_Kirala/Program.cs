using Arac_Kirala.Context;
using Arac_Kirala.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
///////////////////////////////////////////////////////////////
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<ApplicationDbContext>();
/////////////////////////////////////////////////////////////

builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromSeconds(30);
	options.Cookie.IsEssential = true;

});
////////////////////////////////////////////////////////////

builder.Services
	.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		// Kullanýcý doðrulamasý yapýlmamýþsa, Login sayfasýna yönlendirilir.
		options.LoginPath = new PathString("/Login/Index");

		// Kullanýcýnýn eriþim izni olmadýðý sayfalara eriþmeye çalýþtýðýnda, NotFound sayfasýna yönlendirilir.
		options.AccessDeniedPath = new PathString("/Login/PageNotFound");

		// (Opsiyonel) Cookie'nin geçerlilik süresi gibi diðer ayarlarý burada yapýlandýrabilirsiniz.
		// options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Örnek, cookie'nin süresi 30 dakika.
	});
/////////////////////////////////////////////////////

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
