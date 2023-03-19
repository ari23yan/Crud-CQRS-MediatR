using Cqrs.BaseChannel;
using Cqrs.Model;
using Cqrs.ReadRepositories;
using Cqrs.Repositories.WriteRepositories;
using SharpCompress.Common;

namespace Cqrs.BackGroundWorker.AddReadPerson
{
    public class AddReadModelWorker : BackgroundService
    {

        private readonly ChannelQueue<AddPersonModel> _readModelChannel;
        private readonly IServiceProvider _serviceProvider;

        public AddReadModelWorker(ChannelQueue<AddPersonModel> readModelChannel, IServiceProvider serviceProvider)
        {
            _readModelChannel = readModelChannel;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var writeRepository = scope.ServiceProvider.GetRequiredService<WritePersonRepository>();
                var readMovieRepository = scope.ServiceProvider.GetRequiredService<ReadPersonRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var person = await writeRepository.GetMovieByIdAsync(item.Id, stoppingToken);

                        if (person != null)
                        {
                            await readMovieRepository.AddAsync(new Person
                            {
                                Email = person.Email,
                                MobileNumber = person.MobileNumber,
                                Family = person.Family,
                                NationalCode = person.NationalCode,
                                Name = person.Name,
                                Password = person.Password,
                                Addres = person.Addres
                            }, stoppingToken);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Could not update the entity {e.Message}");

                }
            }
        }
    }
}
