using ultraplay_task;
using ultraplay_task.Services;
using ultraplay_task.Services.BetService;
using ultraplay_task.Services.EventService;
using ultraplay_task.Services.MatchService;
using ultraplay_task.Services.OddService;
using ultraplay_task.Services.SportService;
using ultraplay_task.Services.UpdateService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<UltraplayTaskDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<ISportService, SportService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IBetService, BetService>();
builder.Services.AddScoped<IOddService, OddService>();
builder.Services.AddScoped<IUpdateService, UpdateService>();

builder.Services.AddHostedService<XmlService>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
