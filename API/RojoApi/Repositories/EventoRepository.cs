using Microsoft.EntityFrameworkCore;
using RojoAPI.Contexts;
using RojoAPI.Domains;
using RojoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        RojoContext ctx = new RojoContext();
        public void Atualizar(int id, Evento EventoAtualizado)
        {
            Evento EventoBuscada = ctx.Eventos.Find(id);

            if (EventoAtualizado.NomeEvento != null)
            {
                EventoBuscada.NomeEvento = EventoAtualizado.NomeEvento;

                ctx.Eventos.Update(EventoBuscada);

                ctx.SaveChanges();
            }
        }

        public Evento BuscarPorId(int id)
        {
            return ctx.Eventos.FirstOrDefault(x => x.Idevento == id);
        }

        public void Cadastrar(Evento NovoEvento)
        {
            ctx.Eventos.Add(NovoEvento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Eventos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Eventos
           .Include(x => x.IdempresaNavigation)
           .Include(x => x.IdusuarioNavigation)
           .Select(x => new Evento
           {
               Idevento = x.Idevento,
               IdempresaNavigation = x.IdempresaNavigation,
               IdusuarioNavigation = x.IdusuarioNavigation,
               NomeEvento = x.NomeEvento,
               Palestrante = x.Palestrante,
               DataEventoIncio = x.DataEventoIncio,
               DataEventoFim = x.DataEventoFim
           })
           .ToList();
        }
    }
}
