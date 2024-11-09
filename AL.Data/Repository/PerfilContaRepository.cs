using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;

public class PerfilContaRepository : IPerfilContaRepository
{
    private readonly ALContext _context;

    public PerfilContaRepository(ALContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(string contaID)
    {
        return await _context.PerfilContas
            .Include(p => p.Conta)
            .Include(p => p.Produtos)    
            .AsNoTracking()
            .Where(p => p.ContaID == contaID)
            .ToListAsync();
    }

    public async Task<PerfilConta> GetPerfilContaByIdAsync(string perfilContaID)
    {
        var perfilConta = await _context.PerfilContas
                .Include(p => p.Produtos)
                    .ThenInclude(p => p.Feira)
                 .Include(p => p.Produtos)
                    .ThenInclude(p => p.Categoria)
                .SingleOrDefaultAsync(p => p.PerfilContaID == perfilContaID);

        if (perfilConta is null)
            throw new NotFoundException("Nenhum resultado encontrado para identificador da conta fornecido.");

        return perfilConta;
    }

    public async Task<PerfilConta> InsertPerfilContaAsync(PerfilConta perfilConta)
    {
        await _context.PerfilContas.AddAsync(perfilConta);
        await _context.SaveChangesAsync();

        return perfilConta;
    }

    public async Task<PerfilConta> UpdatePerfilContaAsync(PerfilConta perfilConta)
    {
        var perfilContaExistente = await _context.PerfilContas.FindAsync(perfilConta.PerfilContaID);

        if (perfilContaExistente is null)
            throw new NotFoundException("Nenhum resultado encontrado para ID do perfil fornecido.");

        _context.Entry(perfilContaExistente).CurrentValues.SetValues(perfilConta); // Essencialmente, este código copia todos os valores das propriedades da entidade cliente para clienteConsultado, que já está sendo rastreado pelo contexto.Após isso, o Entity Framework irá considerar que conta foi modificado, e quando você chamar SaveChanges(), essas alterações serão persistidas no banco de dados.

        await _context.SaveChangesAsync();
        return perfilContaExistente;
    }

      public async Task DeletePerfilContaAsync(string periflContaID)
    {
        var contaExistente = await _context.PerfilContas.FindAsync(periflContaID);

        if (contaExistente is null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        _context.PerfilContas.Remove(contaExistente);
        await _context.SaveChangesAsync();
    }
}
