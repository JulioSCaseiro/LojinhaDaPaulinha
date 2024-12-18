﻿using LojinhaDaPaulinha.Data.Repositories.Interfaces;

namespace LojinhaDaPaulinha.Data
{
    public class DataUnit : IDataUnit
    {
        private readonly DataContext _context;

        public DataUnit(
            DataContext context,
            IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }

        public IUserRepository Users { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
