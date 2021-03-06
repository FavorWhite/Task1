﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using GameStore.DAL.Intefaces;
using GameStore.DAL.EF;

namespace GameStore.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EF.GameStore _db;
        private GameRepository _gameRepository;
        private CommentRepository _commentRepository;
        private GenreRepository _genreRepository;
        private PlatformTypeRepository _platformTypeRepository;

        public EFUnitOfWork(string connectionString)
        {
            _db = new EF.GameStore(connectionString);
        }

        public IRepository<Game> Game => _gameRepository ?? (_gameRepository = new GameRepository(_db));

        public IRepository<Comment> Comment => _commentRepository ?? (_commentRepository = new CommentRepository(_db));

        public IRepository<Genre> Genre => _genreRepository ?? (_genreRepository = new GenreRepository(_db));

        public IRepository<PlatformType> PlatformType//as example
        {
            get
            {
                if (_platformTypeRepository == null)
                    _platformTypeRepository = new PlatformTypeRepository(_db);
                return _platformTypeRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}