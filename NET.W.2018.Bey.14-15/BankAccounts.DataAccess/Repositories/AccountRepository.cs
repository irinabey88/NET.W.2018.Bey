﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BankAccounts.Common.Interfaces.Repositories;
using BankAccounts.Common.Models;

namespace BankAccounts.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository, IDisposable 
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// The db set
        /// </summary>
        protected readonly DbSet<BankAccount> DbSet;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AccountRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<BankAccount>();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        ~AccountRepository()
        {
            Dispose(false);
        }

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns>Account</returns>
        public BankAccount Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Invalid id : {id}");
            }

            return DbSet.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets account 
        /// </summary>
        /// <param name="model">Account to found</param>
        /// <returns>Found account</returns>
        public BankAccount Get(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return this.Get(model.Id);
        }

        /// <summary>
        /// Addes new account to repository
        /// </summary>
        /// <param name="model">Account</param>
        /// <returns>Added account</returns>
        public BankAccount Add(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var result = DbSet.Add(model);
            Context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates account in repository
        /// </summary>
        /// <param name="model">Account</param>
        /// <returns>Updated account</returns>
        public BankAccount Update(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            BankAccount entity = Get(model.Id);            
            Context.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Gets all accounts in repository
        /// </summary>
        /// <returns>List of accounts</returns>
        public IEnumerable<BankAccount> GetAllElements()
        {
            return this.DbSet.ToList();
        }
        
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Dispose pattern
        /// </summary>
        /// <param name="flag">The flag</param>
        protected virtual void Dispose(bool flag)
        {
            if (_disposed)
            {
                return;
            }

            Context.Dispose();
            _disposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}