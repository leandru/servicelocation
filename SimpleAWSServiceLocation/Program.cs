using Amazon;
using Amazon.LocationService;
using SimpleAWSServiceLocation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAmazonLocationService>(provider =>
{
    return new AmazonLocationServiceClient(RegionEndpoint.SAEast1);
});
builder.Services.AddScoped<LocationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region EndPoints
app.MapGet("/search/{place}", async ( LocationService location, string place) =>
{
    var data = DateTime.Now;
    return await location.SearchPlace(place);
})
.WithName("SearchPlace")
.WithOpenApi();

#endregion

app.Run();

