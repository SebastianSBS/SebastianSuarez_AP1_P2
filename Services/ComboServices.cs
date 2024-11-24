using Microsoft.EntityFrameworkCore;
using SebastianSuarez_AP1_P2.DAL;
using SebastianSuarez_AP1_P2.Models;
using System.Linq.Expressions;

namespace SebastianSuarez_AP1_P2.Services
{
        public class ComboServices(IDbContextFactory<Context> DbFactory)
    {
        private readonly Context _context;
        public async Task<bool> Existe(int RegistroComboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.Combo.AnyAsync(c => c.ComboId == RegistroComboId);

        }

        public async Task<bool> Insertar(Combos registroCombo)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();

            foreach (var combo in registroCombo.ComboDetalle)
            {
                var articulo = await BuscarArticulos(combo.ArticuloId);

                if (articulo != null)
                {
                    if (articulo.Existencia < combo.Cantidad)
                    {
                        return false;
                    }
                    articulo.Existencia -= combo.Cantidad;
                    _context.Articulos.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                else
                {

                    return false;
                }
            }
            _context.Combo.Add(registroCombo);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Modificar(Combos registroCombo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            contexto.Update(registroCombo);
            return await contexto.SaveChangesAsync() > 0;
        }


        public async Task<bool> Guardar(Combos Combo)
        {
            if (!await Existe(Combo.ComboId))
            {
                return await Insertar(Combo);
            }
            else
                return await Modificar(Combo);
        }


        public async Task<bool> Eliminar(int ComboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            var detalles = await BuscarRegistroComboDetalle(ComboId);

            foreach (var detalle in detalles)
            {
                var articulo = await BuscarArticulos(detalle.ArticuloId);
                if (articulo != null)
                {
                    articulo.Existencia += detalle.Cantidad;
                    await ActualizarArticulo(articulo);
                }
            }
            var cobro = await _context.Combo
                        .Include(c => c.ComboDetalle)
                        .FirstOrDefaultAsync(c => c.ComboId == ComboId);

            if (cobro == null) return false;

            _context.
                ComboDetalle.RemoveRange(cobro.ComboDetalle);
            _context.Combo.Remove(cobro);

            var cantidad = await _context.SaveChangesAsync();
            return cantidad > 0;
        }


        public async Task<bool> EliminarDetalle(int detalleId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            if (await ExisteDetalle(detalleId))
            {
                var comboDetalle = await _context.ComboDetalle.FirstOrDefaultAsync(c => c.DetalleId == detalleId);

                var articulo = await _context.Articulos.FindAsync(comboDetalle.ArticuloId);

                if (articulo is null)
                {
                    return false;
                }
                else
                {
                    articulo.Existencia += comboDetalle.Cantidad;
                    _context.Articulos.Update(articulo);
                }
                _context.ComboDetalle.Remove(comboDetalle);
            }

            else
            {
                var combos = await _context.ComboDetalle.FirstOrDefaultAsync(c => c.DetalleId == detalleId);

                if (combos is null)
                {
                    return false;
                }

                _context.ComboDetalle.Remove(combos);
            }

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Articulos> BuscarArticulos(int id)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ArticuloId == id);
        }


        public async Task<bool> ActualizarArticulo(Articulos articulo)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            _context.Articulos.Update(articulo);
            return await _context
                .SaveChangesAsync() > 0;
        }


        public async Task<Combos> Buscar(int ComboId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo
                .Include(c => c.ComboDetalle)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ComboId == ComboId);
        }


        public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo
                .Include(c => c.ComboDetalle)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<Articulos>> GetArticulos()
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.Articulos
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<CombosDetalle>> BuscarRegistroComboDetalle(int comboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.ComboDetalle
                .Include(a => a.Articulos)
                .Where(t => t.ComboId == comboId)
                 .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<CombosDetalle>> ListarComboDetalle(int comboId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            var cotizacionDetalle = await _context.ComboDetalle
                .Where(d => d.ComboId == comboId)
                .ToListAsync();

            return cotizacionDetalle;
        }


        private async Task<bool> ExisteDetalle(int detalleId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.ComboDetalle.AnyAsync(ed => ed.DetalleId == detalleId);
        }
    }
}

