using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;

public class ContaRepository : IContaRepository, IContaValidationRepository
{
    private readonly ALContext _context;

    public ContaRepository(ALContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<Conta>> GetContasAsync()
    {
        return await _context.Contas.AsNoTracking().ToListAsync();
    }

    public async Task<Conta> GetContaByIdAsync(int id)
    {
        var conta = await _context.Contas
                    .SingleOrDefaultAsync(p => p.ContaID == id);

        if (conta is null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        return conta;
    }

    public async Task<Conta> InsertContaAsync(Conta conta)
    {
        await _context.Contas.AddAsync(conta);
        await _context.SaveChangesAsync();

        return conta;
    }

    public async Task<Conta> UpdateContaAsync(Conta conta)
    {
        var contaExistente = await _context.Contas.FindAsync(conta.ContaID);

        if (contaExistente is null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        _context.Entry(contaExistente).CurrentValues.SetValues(conta); // Essencialmente, este código copia todos os valores das propriedades da entidade cliente para clienteConsultado, que já está sendo rastreado pelo contexto.Após isso, o Entity Framework irá considerar que conta foi modificado, e quando você chamar SaveChanges(), essas alterações serão persistidas no banco de dados.

        //_context.Contas.Update(contaExistente); // não é necessário fazer o update, pois na linha 51 está fazendo esse trabalho no "SetValues"

        await _context.SaveChangesAsync();
        return contaExistente;
    }

    public async Task DeleteContaAsync(int id)
    {
        var contaExistente = await _context.Contas.FindAsync(id);

        if (contaExistente is null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        _context.Contas.Remove(contaExistente);
        await _context.SaveChangesAsync();
    }

    public Conta GetContaByEmailAsync(string email)
    {
        var conta = _context.Contas
            .FirstOrDefault(c => c.Email.ToLower() == email.ToLower());

        if (conta is null)
            throw new NotFoundException(ExceptionMessages.NotFoundAccountEmail);

        return conta;
    }
}
