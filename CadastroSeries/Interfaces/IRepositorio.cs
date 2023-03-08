using System.Collections.Generic;

namespace CadastroSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetonraPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
         
    }
}