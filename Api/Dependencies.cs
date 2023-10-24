using DAL.Interfaces;
using DAL.Repositories;
using Service.Implementations;
using Service.Interfaces;

namespace Api
{
    public static class Dependencies
    {
        public static void InititalizationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<ITicketService, TicketService>();
        }

        public static void InititalizationRepostitories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppointmentRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, TicketRepository>();
        }
    }
}
