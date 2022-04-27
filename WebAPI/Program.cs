using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mappings;
using Core.Extensions;
using Core.Utilities.Security.Token;
using Core.Utilities.Security.Token.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ECommerceProjectWithWebAPIContext>();

#region DI
builder.Services.AddTransient<IUserDal, EfUserDal>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITokenService, JwtTokenService>();
builder.Services.AddTransient<IAuthService, AuthService>();
#endregion

#region AutoMapper
var mapperConfiguration = new MapperConfiguration(configuration =>
{
    configuration.AddProfile(new MappingProfile());
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

builder.Services.AddControllers();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomJwtToken(builder.Configuration);


// --------------------------------------------------------------------------------- //



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization();  // Yetkilendirme

app.MapControllers();

app.Run();