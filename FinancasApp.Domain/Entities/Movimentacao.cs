namespace FinancasApp.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateOnly Data { get; set; }
        public int TipoMovimentacaoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }

    public enum TipoMovimentacao
    {
        Receita = 1,
        Despesa = 2
    }
}
