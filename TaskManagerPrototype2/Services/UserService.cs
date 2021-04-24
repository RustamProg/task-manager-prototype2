using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TaskManagerPrototype2.Helpers;
using TaskManagerPrototype2.Models.Auth;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public class UserService: IUserService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IConfiguration _configuration;

        public UserService(IDbRepository repository, IConfiguration configuration)
        {
            _dbRepository = repository;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dbRepository.GetAll()
                .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public AuthenticateResponse Register(User user)
        {
            _dbRepository.Add(user);

            var response = Authenticate(new AuthenticateRequest
            {
                Username = user.Username,
                Password = user.Password
            });

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _dbRepository.GetById(id);
        }
    }
}