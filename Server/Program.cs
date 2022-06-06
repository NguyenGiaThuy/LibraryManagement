var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Repositories
builder.Services.AddTransient<Server.Repositories.ILibBookAuditCardsRepository, Server.Repositories.LibBookAuditCardsRepository>();
builder.Services.AddTransient<Server.Repositories.ILibBooksRepository, Server.Repositories.LibBooksRepository>();
builder.Services.AddTransient<Server.Repositories.ILibCallCardsRepository, Server.Repositories.LibCallCardsRepository>();
builder.Services.AddTransient<Server.Repositories.ILibFineCardsRepository, Server.Repositories.LibFineCardsRepository>();
builder.Services.AddTransient<Server.Repositories.ILibMembershipsRepository, Server.Repositories.LibMembershipsRepository>();
builder.Services.AddTransient<Server.Repositories.ILibMembersRepository, Server.Repositories.LibMembersRepository>();
builder.Services.AddTransient<Server.Repositories.ILibUsersRepository, Server.Repositories.LibUsersRepository>();

builder.Services.AddDbContext<Server.Models.LibraryManagementContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
