using System;
using Microsoft.EntityFrameworkCore;
using Pedidos.Domain;
using Pedidos.ValueObjects;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Data.ApplicationContext();

            var existe = db.Database.GetPendingMigrations().Any();
            if (existe)
            {
                // codigo
            }

            InserirDados();
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1235465436",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();

            db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine(registros);
        }

    }

}