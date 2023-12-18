using Redis_Distributed_Caching.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Redis
builder.Configuration.AddJsonFile("appsettings.json");
var redisOptions = builder.Configuration.GetSection("RedisConnection").Get<RedisConnectionOptions>();
builder.Services.AddStackExchangeRedisCache(opt =>
{
    //Default Redis Port
    opt.Configuration = redisOptions.Configuration;
    opt.InstanceName = redisOptions.InstanceName;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
