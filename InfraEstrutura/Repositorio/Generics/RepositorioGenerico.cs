using Dominio.Interfaces.Generics;
using InfraEstrutura.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repositorio.Generics
{
    public class RepositorioGenerico<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Adicionar(T Objeto)
        {
            using (var dados = new ContextBase(_OptionsBuilder))
            {
                await dados.Set<T>().AddAsync(Objeto);
                await dados.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T Objeto)
        {
            using (var dados  = new ContextBase(_OptionsBuilder))
            {
                dados.Set<T>().Update(Objeto);
                await dados.SaveChangesAsync();
            }
        }

        public async Task Excluir(T Objeto)
        {
            using (var dados = new ContextBase(_OptionsBuilder))
            {
                dados.Set<T>().Remove(Objeto);
                await dados.SaveChangesAsync();
            }
        }

        public async Task<List<T>> List()
        {
            using (var dados = new ContextBase(_OptionsBuilder))
            {
                return await dados.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> ObterEntidadePorId(int Id)
        {
            using (var dados = new ContextBase(_OptionsBuilder))
            {
                return await dados.Set<T>().FindAsync(Id);
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        bool disposed = false;        

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}
