
using MouseProcessing.Domain.Abstractions;
using MouseProcessing.Domain.BaseTypes;
using MouseProcessing.Domain.Entities;
using MouseProcessing.Application.Services;
using MouseProcessing.Infrastructure.Entities;
using MouseProcessing.Infrastructure.Mappers;
using MouseProcessing.Infrastructure.Repositories;
using MouseProcessing.API.Mappers;
using MouseProcessing.API.Dtos;

namespace MouseProcessing.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICursorInfoService, CursorInfoService>();
            builder.Services.AddScoped<ICursorInfoRepository, EFCursorInfoRepository>();
            builder.Services.AddScoped<IMapper<CursorInfo, CursorInfoEntity>, CursorInfoEntityMapper>();
            builder.Services.AddScoped<IMapper<CursorInfo, CursorInfoCreateDto>, CursorInfoCreateDtoMapper>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
